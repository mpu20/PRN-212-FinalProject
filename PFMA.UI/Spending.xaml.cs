using PFMA.Data;
using PFMA.Interface.ViewModels;
using PFMA.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Spending.xaml
    /// </summary>
    public partial class Spending : UserControl
    {
        public Spending()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new SpendingViewModel();
            }
        }
    }
}
