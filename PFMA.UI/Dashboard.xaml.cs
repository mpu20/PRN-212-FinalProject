using PFMA.Interface.ViewModels;
using System;
using System.Windows.Controls;

namespace PFMA.Interface
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            cboAnalytics.SelectedIndex = DateTime.Now.Month < 7 ? 0 : 1;
            DataContext = new TransactionViewModel();
        }
    }
}
