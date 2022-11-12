// See https://aka.ms/new-console-template for more information
using HouseBills;

using HouseBills.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

//Console.WriteLine("Hello, World!");

//IBillsRepository billsRepository = new BillsRepository();


var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices(services =>
services
.AddScoped<IBillService, BillServices>()
.AddScoped<IBillsRepository, BillsRepository>());

using var host = builder.Build();

host.Run();


MenuServices menuServices = new MenuServices();

menuServices.MenuAction();

