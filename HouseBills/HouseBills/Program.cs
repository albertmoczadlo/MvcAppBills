// See https://aka.ms/new-console-template for more information
using HouseBills;

using HouseBills.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

//Console.WriteLine("Hello, World!");

using IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((_, services) =>
        services         
            .AddScoped<IBillsRepository, BillsRepository>()
            .AddScoped<IBillService, BillServices>()
            .AddSingleton<MenuServices>()
            )
    .Build();

host.Services.GetRequiredService<MenuServices>().MenuAction();










