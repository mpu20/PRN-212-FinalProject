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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private UserViewModel _viewModel;

        public Login()
        {
            InitializeComponent();
            _viewModel = new UserViewModel(new UserService(new DataContext()));
            this.DataContext = _viewModel;
            txtPassword.PasswordChanged += (sender, args) =>
            {
                _viewModel.Password = txtPassword.Password;
            };
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow!.NavigateToRegister();
        }
    }
}
