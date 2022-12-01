
using HouseBills;
using HouseBills.Application.Services;
using HouseBills.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((_, services) =>
        services  
            .AddSingleton<MenuServices>()
            )
    .Build();

host.Services.GetRequiredService<MenuServices>().MenuAction();










