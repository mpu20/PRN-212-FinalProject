using PFMA.Interface.ViewModels;
using System.Windows.Controls;

namespace PFMA.Interface
{
    /// <summary>
    /// Interaction logic for Income.xaml
    /// </summary>
    public partial class Income : Page
    {
        public Income()
        {
            InitializeComponent();
            DataContext = new IncomeViewModel();
        }
    }
}
