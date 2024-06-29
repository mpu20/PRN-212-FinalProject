using PFMA.Data;
using PFMA.Interface.ViewModels;
using PFMA.Service;
using System.ComponentModel;
using System.Windows.Controls;

namespace PFMA.Interface
{
    /// <summary>
    /// Interaction logic for FinancialFlow.xaml
    /// </summary>
    public partial class FinancialFlow : UserControl
    {
        public FinancialFlow()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new FinancialFlowViewModel(new IncomeService(new DataContext()), new ExpenseService(new DataContext()));
            }
        }
    }
}
