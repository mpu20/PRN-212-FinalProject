using PFMA.Data;
using PFMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMA.Service
{
    public class IncomeService
    {
        private readonly DataContext _context;
        public IncomeService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Income> GetIncomes()
        {
            return _context.Incomes.ToList();
        }
        public Income? GetIncome(Guid id)
        {
            return _context.Incomes.FirstOrDefault(i => i.Id == id);
        }
        public void AddIncome(Income income)
        {
            _context.Incomes.Add(income);
            _context.SaveChanges();
        }
        public void UpdateIncome(Income income)
        {
            var _income = GetIncome(income.Id);
            if (_income != null)
            {
                _income.Source = income.Source;
                _income.Amount = income.Amount;
                _income.ReceivedDate = income.ReceivedDate;
                _income.Description = income.Description;
                
                _context.SaveChanges();
            }
        }
        public void RemoveIncome(Guid id)
        {
            var income = GetIncome(id);
            if (income != null)
            {
                income.User = null;
                _context.Incomes.Remove(income);
                _context.SaveChanges();
            }
        }
    }
}
