﻿using PFMA.Data;
using PFMA.Interface.ViewModels;
using PFMA.Service;
using System.ComponentModel;
using System.Windows.Controls;

namespace PFMA.Interface
{
    /// <summary>
    /// Interaction logic for Analytics.xaml
    /// </summary>
    public partial class Analytics : UserControl
    {
        private AnalyticsViewModel _viewModel;

        public Analytics()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                _viewModel = new AnalyticsViewModel(new IncomeService(new DataContext()), new ExpenseService(new DataContext()));
                DataContext = _viewModel;
            }
        }
    }
}
