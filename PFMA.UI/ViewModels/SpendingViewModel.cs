using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using PFMA.Data;
using PFMA.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFMA.Interface.ViewModels
{
    public class SpendingViewModel : ObservableObject
    {
        private readonly ExpenseService _expenseService = new(new DataContext());

        public IEnumerable<ISeries> Series { get; set; }

        public SpendingViewModel()
        {
            LoadChartData();
        }

        [Obsolete]
        private void LoadChartData()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var expensesThisMonth = _expenseService.GetExpenses()
                .Where(e => e.IncurredDate >= startOfMonth)
                .ToList();

            var categoryExpenses = expensesThisMonth
                .GroupBy(e => e.Category.Name)
                .Select(group => new PieSeries<decimal>
                {
                    Name = group.Key,
                    Values = new List<decimal> { group.Sum(e => e.Amount) },
                    DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(255, 255, 255)),
                    DataLabelsPosition = PolarLabelsPosition.Middle,
                    DataLabelsSize = 15,
                    TooltipLabelFormatter = point => $"{point.Context.Series.Name}: ${point.PrimaryValue}"
                });

            Series = categoryExpenses;
        }
    }
}
