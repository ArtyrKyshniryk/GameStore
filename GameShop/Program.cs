
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using BLL.Infastructure;
using DLL.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using GameShop.Services;
using Serilog;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri("https://gameshopvault.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
var connectionString = builder.Configuration.GetValue(typeof(string), "DefaultConnection").ToString();


builder.Host.UseSerilog((hostingContext, services, configuration) =>
{
    configuration.WriteTo.File(builder.Environment.WebRootPath + "/Log.txt");
});


var identityBuilder = builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<GameStoreContext>();
builder.Services.AddTransient<IEmailSender, SenGridEmailSender>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

Configuration.ConfigurationService(builder.Services, connectionString, identityBuilder); ;//Config Busineskg

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
