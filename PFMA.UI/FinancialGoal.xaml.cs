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
    /// Interaction logic for FinancialGoal.xaml
    /// </summary>
    public partial class FinancialGoal : Page
    {
        private readonly FinancialGoalService _financialGoalService;

        public FinancialGoal()
        {
            InitializeComponent();
            _financialGoalService = new FinancialGoalService(new Data.DataContext());
            LoadFinancialGoals();
        }

        private void LoadFinancialGoals(DateTime? selectedMonth = null)
        {
            var financialGoals = _financialGoalService.GetFinancialGoals(selectedMonth);
            FinancialGoalsListView.ItemsSource = financialGoals;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;
            var content = selectedItem.Content.ToString();

            DateTime? selectedMonth = content == "This month" ? DateTime.Now : (content == "Last month" ? DateTime.Now.AddMonths(-1) : null);

            LoadFinancialGoals(selectedMonth);
        }
    }
}
