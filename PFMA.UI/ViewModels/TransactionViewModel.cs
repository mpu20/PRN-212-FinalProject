using PFMA.Data;
using PFMA.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFMA.Interface.ViewModels
{
    public class TransactionViewModel
    {
        private readonly IncomeService incomeService = new(new DataContext());
        private readonly ExpenseService expenseService = new(new DataContext());

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public string FormattedAmount
        {
            get
            {
                var prefix = IsIncome ? "+" : "-";
                return $"{prefix}${Math.Abs(Amount):N0}";
            }
        }
        public string IconPath => IsIncome ? "pack://application:,,,/Assets/Icons/income_white.png" : "pack://application:,,,/Assets/Icons/expense_white.png";

        public List<TransactionViewModel> LatestTransactions { get; set; }

        public TransactionViewModel()
        {
            LatestTransactions = incomeService.GetIncomes()
                .Select(i => new TransactionViewModel { Date = i.ReceivedDate, Amount = i.Amount, IsIncome = true })
                .Concat(expenseService.GetExpenses()
                .Select(e => new TransactionViewModel { Date = e.IncurredDate, Amount = e.Amount, IsIncome = false }))
                .OrderByDescending(t => t.Date)
                .Take(3)
                .ToList();
        }
    }
}
