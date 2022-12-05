using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HouseBills.Infrastructure;
using HouseBills.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using HouseBills.Services;
using SendGrid.Helpers.Mail;
using SendGrid;

var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<HouseBillsWebMvcDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HouseBillsWebMvcDbContextConnection") ?? throw new InvalidOperationException("Connection string 'WebMvcDbHouseBillsWebMvcContext' not found.")));
        var connectionString = builder.Configuration.GetConnectionString("HouseBillsWebMvcDbContextConnection") ?? throw new InvalidOperationException("Connection string 'HouseBillsWebMvcDbContextConnection' not found.");


        builder.Services.AddControllers();

        builder.Services.AddDbContext<HouseBillsWebMvcDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<UserApp>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<HouseBillsWebMvcDbContext>();

        builder.Services.AddTransient<IEmailSender, EmailSender>();
        builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

// Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); ;

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();

app.Run();
