
using HouseBills;
using HouseBills.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((_, services) =>
        services         
            .AddScoped<IBillsRepository, BillsRepository>()
            .AddScoped<IBillService, BillServices>()
            .AddSingleton<MenuServices>()
            )
    .Build();

host.Services.GetRequiredService<MenuServices>().MenuAction();










