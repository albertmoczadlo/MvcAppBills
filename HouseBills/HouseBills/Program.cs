// See https://aka.ms/new-console-template for more information
using HouseBills;

using HouseBills.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

//Console.WriteLine("Hello, World!");

//IBillsRepository billsRepository = new BillsRepository();

//BillServices billServices = new BillServices(billsRepository);

//billServices.RegisterBill();

//Console.WriteLine("");

//billServices.ShowList();


IBillsRepository billsRepository = new BillsRepository();
Bills bills = new Bills();

IBillService billService = new BillServices(billsRepository,bills);

MenuServices menuServices = new MenuServices(billService,billsRepository);

menuServices.MenuAction();

