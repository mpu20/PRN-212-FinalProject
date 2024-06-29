using PFMA.Data;
using PFMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMA.Service
{
    public class ExpenseService
    {
        private readonly DataContext _context;
        public ExpenseService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Expense> GetExpenses()
        {
            return _context.Expenses.ToList();
        }
        public Expense? GetExpense(Guid id)
        {
            return _context.Expenses.FirstOrDefault(e => e.Id == id);
        }
        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }
        public void UpdateExpense(Expense expense)
        {
            var _expense = GetExpense(expense.Id);
            if (_expense != null)
            {
                _expense.Amount = expense.Amount;
                _expense.CategoryId = expense.CategoryId;
                _expense.IncurredDate = expense.IncurredDate;

                _context.SaveChanges();
            }
        }
        public void RemoveExpense(Guid id)
        {
            var expense = GetExpense(id);
            if (expense != null)
            {
                expense.User = null!;
                expense.Category = null!;
                _context.Expenses.Remove(expense);

                _context.SaveChanges();
            }
        }
    }
}