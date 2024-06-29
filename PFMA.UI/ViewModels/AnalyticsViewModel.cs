using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using PFMA.Service;
using System;
using System.Linq;

namespace PFMA.Interface.ViewModels
{
    public class AnalyticsViewModel : ObservableObject
    {
        private IncomeService _incomeService;
        private ExpenseService _expenseService;

        public ISeries[] Series { get; set; }
        public Axis[] XAxes { get; set; }

        public AnalyticsViewModel(IncomeService incomeService, ExpenseService expenseService)
        {
            _incomeService = incomeService;
            _expenseService = expenseService;
            LoadChartData();
        }

        private void LoadChartData()
        {
            var incomes = _incomeService.GetIncomes()
                .GroupBy(i => new { i.ReceivedDate.Year, i.ReceivedDate.Month })
                .Select(g => new { Month = new DateTime(g.Key.Year, g.Key.Month, 1), Total = g.Sum(i => i.Amount) })
                .OrderBy(x => x.Month);

            var expenses = _expenseService.GetExpenses()
                .GroupBy(e => new { e.IncurredDate.Year, e.IncurredDate.Month })
                .Select(g => new { Month = new DateTime(g.Key.Year, g.Key.Month, 1), Total = g.Sum(e => e.Amount) })
                .OrderBy(x => x.Month);

            var months = incomes.Select(i => i.Month.ToString("yyyy-MM")).Union(expenses.Select(e => e.Month.ToString("yyyy-MM"))).Distinct().OrderBy(x => x);

            Series =
            [
                new ColumnSeries<double>
                {
                    Values = months.Select(m => (double)(incomes.FirstOrDefault(i => i.Month.ToString("yyyy-MM") == m)?.Total ?? 0)).ToArray(),
                    Name = "Income",
                    Stroke = null
                },
                new ColumnSeries<double>
                {
                    Values = months.Select(m => (double)(expenses.FirstOrDefault(e => e.Month.ToString("yyyy-MM") == m)?.Total ?? 0)).ToArray(),
                    Name = "Expenses",
                    Stroke = null
                }
            ];

            XAxes =
            [
                new Axis
                {
                    Labels = months.ToArray(),
                    LabelsRotation = 0
                }
            ];
        }
    }
}
