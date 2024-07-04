using PFMA.Data;
using PFMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMA.Service
{
    public class FinancialGoalService
    {
        private readonly DataContext _context;

        public FinancialGoalService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<FinancialGoal> GetFinancialGoals(DateTime? selectedMonth)
        {
            DateTime time = selectedMonth ?? DateTime.Now;
            var startOfMonth = new DateTime(time.Year, time.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            return _context.FinancialGoals!
                .Where(fg => fg.DueDate >= startOfMonth && fg.DueDate <= endOfMonth)
                .OrderBy(fg => fg.DueDate);
        }

        public FinancialGoal? GetFinancialGoal(Guid id) => _context.FinancialGoals.FirstOrDefault(fg => fg.Id == id);

        public void AddFinancialGoal(FinancialGoal financialGoal)
        {
            _context.FinancialGoals.Add(financialGoal);
            _context.SaveChanges();
        }

        public void UpdateFinancialGoal(FinancialGoal financialGoal)
        {
            var _financialGoal = GetFinancialGoal(financialGoal.Id);
            if (_financialGoal != null)
            {
                _financialGoal.Name = financialGoal.Name;
                _financialGoal.TargetAmount = financialGoal.TargetAmount;
                _financialGoal.CurrentAmount = financialGoal.CurrentAmount;
                _financialGoal.DueDate = financialGoal.DueDate;
                _financialGoal.Description = financialGoal.Description;

                _context.SaveChanges();
            }
        }

        public void RemoveFinancialGoal(Guid id)
        {
            var financialGoal = GetFinancialGoal(id);
            if (financialGoal != null)
            {
                financialGoal.User = null!;
                _context.FinancialGoals.Remove(financialGoal);

                _context.SaveChanges();
            }
        }
    }
}
