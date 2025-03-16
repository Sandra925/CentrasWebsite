using Centras.db;
using Centras.Models;
using Centras.Resources;
using Centras.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
var logPath = "/logs/log.txt";
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
    .CreateLogger();

var secret = Environment.GetEnvironmentVariable("SmtpPass");
builder.Host.UseSerilog();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CentrasContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddRazorPages()
.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)

.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (_, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(Res).GetTypeInfo().Assembly.FullName!);
        return factory.Create(nameof(Res), assemblyName.Name!);
    };
});


#if Release


builder.Services.AddSingleton<SmtpEmailService>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    return new SmtpEmailService(configuration,secret);
});
#else
    builder.Services.AddSingleton<SmtpEmailService>();
#endif


var supportedCultures = new List<CultureInfo>
{
    new CultureInfo( "lt" ),
    new CultureInfo( "en" )
    
};
var options = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("lt"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),      
        new AcceptLanguageHeaderRequestCultureProvider() 
    }
};
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "CentrasCookie"; // Custom cookie name
        options.LoginPath = "/Login"; // Redirect to this page if not authenticated
        options.AccessDeniedPath = "/AccessDenied"; // Redirect here if authorization fails
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration time
        options.SlidingExpiration = true; // Reset the expiration time on each request
        options.Cookie.HttpOnly = true; // Prevent client-side script access to the cookie
        options.Cookie.SameSite = SameSiteMode.Strict; // Enhance security
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure cookies are only sent over HTTPS
    });
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminOnly", policy => policy.RequireRole("Administratorius"));


var app = builder.Build();
app.UseSession();
app.UseRequestLocalization(options);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
