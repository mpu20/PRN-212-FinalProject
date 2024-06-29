using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using PFMA.Service;
using System;
using System.Globalization;
using System.Linq;

namespace PFMA.Interface.ViewModels
{
    public class FinancialFlowViewModel : ObservableObject
    {
        private readonly IncomeService _incomeService;
        private readonly ExpenseService _expenseService;

        public ISeries[] IncomeSeries { get; private set; }
        public ISeries[] ExpenseSeries { get; private set; }
        public Axis[] XAxes { get; private set; }

        public FinancialFlowViewModel(IncomeService incomeService, ExpenseService expenseService)
        {
            _incomeService = incomeService;
            _expenseService = expenseService;
            LoadChartData();
        }

        private void LoadChartData()
        {
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var daysOfWeek = Enumerable.Range(0, 7).Select(i => startOfWeek.AddDays(i)).ToArray();

            IncomeSeries =
            [
                new ColumnSeries<double>
                {
                    Values = daysOfWeek.Select(day => _incomeService.GetIncomes()
                        .Where(income => income.ReceivedDate.Date == day.Date)
                        .Sum(income => (double)income.Amount)).ToArray(),
                    Name = "Income"
                }
            ];

            ExpenseSeries =
            [
                new ColumnSeries<double>
                {
                    Values = daysOfWeek.Select(day => _expenseService.GetExpenses()
                        .Where(expense => expense.IncurredDate.Date == day.Date)
                        .Sum(expense => (double)expense.Amount)).ToArray(),
                    Name = "Expense"
                }
            ];

            XAxes =
            [
                new Axis
                {
                    Labels = daysOfWeek.Select(day => day.ToString("ddd", CultureInfo.InvariantCulture)).ToArray()
                }
            ];
        }
    }
}
