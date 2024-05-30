using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PFMA.Data.Repositories.Interfaces;

namespace PFMA.Interface;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var userRepository = ServiceProvider.Instance.GetService<IUserRepository>();
        var register = new Register(userRepository);
        var window = new Window
        {
            Content = register
        };
        window.Show();
    }
}