using System.Windows;
using System.Windows.Navigation;
using PFMA.Data.Repositories.Interfaces;
using PFMA.Interface.ViewModels;

namespace PFMA.Interface
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        private readonly LoginViewModel _viewModel;

        public Login(IUserRepository userRepository)
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(userRepository);
            DataContext = _viewModel;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = await _viewModel.Login(tbEmail.Text, tbPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Email or password is incorrect");
            }
            else
            {
                var dashboard = new Dashboard();
                var navigateWindow = new NavigationWindow()
                {
                    Content = dashboard
                };
                
                navigateWindow.Show();
                Close();
            }
        }
    }
}