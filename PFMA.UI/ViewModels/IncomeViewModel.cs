using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using PFMA.Data;
using PFMA.Service;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFMA.Interface.ViewModels
{
    public class IncomeViewModel : ObservableObject
    {
        private readonly IncomeService _incomeService = new(new DataContext());

        public ISeries[] Series { get; private set; }
        public Axis[] XAxes { get; private set; }
        public IEnumerable<Data.Models.Income> Incomes { get; private set; }

        public IncomeViewModel()
        {
            LoadChartData();
            LoadTenIncomes();
        }

        private void LoadChartData()
        {
            var incomesThisMonth = _incomeService.GetIncomes()
                .Where(i => i.ReceivedDate.Year == DateTime.Now.Year && i.ReceivedDate.Month == DateTime.Now.Month)
                .GroupBy(i => i.ReceivedDate.Day)
                .Select(group => new { Day = group.Key, Total = group.Sum(i => i.Amount) })
                .OrderBy(x => x.Day)
                .ToList();

            Series =
            [
                new ColumnSeries<decimal>
                {
                    Values = incomesThisMonth.Select(x => x.Total).ToArray(),
                    DataLabelsPaint = new SolidColorPaint { Color = SKColors.Black },
                    DataLabelsPosition = DataLabelsPosition.End,
                    DataLabelsSize = 14,
                    Name = "Income"
                }
            ];

            XAxes =
            [
                new Axis
                {
                    Labels = incomesThisMonth.Select(x => x.Day.ToString()).ToArray(),
                    LabelsRotation = 15
                }
            ];

            OnPropertyChanged(nameof(Series));
            OnPropertyChanged(nameof(XAxes));
        }

        private void LoadTenIncomes()
        {
            Incomes = _incomeService.GetIncomes()
                .OrderByDescending(i => i.ReceivedDate)
                .Take(10).ToList();


            OnPropertyChanged(nameof(Incomes));
        }
    }
}
