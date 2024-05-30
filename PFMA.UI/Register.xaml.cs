using System;
using System.Windows;
using PFMA.Common;
using PFMA.Data.Models;
using PFMA.Data.Repositories.Interfaces;
using PFMA.Interface.ViewModels;

namespace PFMA.Interface;

public partial class Register
{
    private readonly RegisterViewModel _viewModel;
    private readonly IUserRepository _userRepository;
    
    public Register(IUserRepository userRepository)
    {
        InitializeComponent();
        _userRepository = userRepository;
        _viewModel = new RegisterViewModel(userRepository);
        DataContext = _viewModel;
    }

    private async void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        if (tbPassword.Text.Equals(tbConfirmPassword.Text))
        {
            try
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = tbEmail.Text,
                    PasswordHash = tbPassword.Text,
                    FullName = tbFullname.Text,
                    CreatedAt = DateTime.UtcNow,
                    Status = UserStatus.Active
                };

                await _viewModel.Register(user);

                MessageBox.Show("User registered successfully");

                var login = new Login(_userRepository);
                login.Show();

                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        else
        {
            MessageBox.Show("Passwords do not match");
        }
    }
}