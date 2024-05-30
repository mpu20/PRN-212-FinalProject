using System;
using Microsoft.Extensions.DependencyInjection;
using PFMA.Data;
using PFMA.Data.Repositories;
using PFMA.Data.Repositories.Interfaces;

namespace PFMA.Interface;

public static class ServiceProvider
{
    public static IServiceProvider Instance { get; }

    static ServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<DataContext>();

        Instance = services.BuildServiceProvider();
    }
}