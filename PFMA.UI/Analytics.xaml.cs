using PFMA.Data;
using PFMA.Interface.ViewModels;
using PFMA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            _viewModel = new AnalyticsViewModel(new IncomeService(new DataContext()), new ExpenseService(new DataContext()));
            DataContext = _viewModel;
        }
    }
}
