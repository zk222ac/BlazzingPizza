using BlazzingPizza.Server.Data;
using BlazzingPizza.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlazzingPizza.Server.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using BlazzingPizza.Server.Data.Repositories;
//using NLog;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Logger Service
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(
    options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

// Add IPizzaSpecialRep Service
builder.Services.AddScoped<IPizzaSpecialRepo, PizzaSpecialRepo>();
// Add Automapper service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();
// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!db.Database.EnsureCreated())
    {
        try
        {
            SeedData.Initialize(db);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }

}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.MapPizzaApi();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
