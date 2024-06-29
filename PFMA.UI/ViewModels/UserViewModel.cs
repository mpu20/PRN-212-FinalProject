using CommunityToolkit.Mvvm.Input;
using PFMA.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PFMA.Interface.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    OnPropertyChanged(nameof(ConfirmPassword));
                }
            }
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public UserViewModel(UserService userService)
        {
            _userService = userService;
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Login()
        {
            var user = _userService.Login(Email, Password);
            if (user != null)
            {
                MessageBox.Show("Successfully log in", "Login", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Invalid email or password", "Login", MessageBoxButton.OK);
            }
        }

        private void Register()
        {
            if (!Password.Equals(ConfirmPassword))
            {
                MessageBox.Show("Password does not match", "Register", MessageBoxButton.OK);
                return;
            }
            _userService.Register(FullName, Email, Password);
        }
    }
}
