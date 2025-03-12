using Centras.db;
using Centras.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

builder.Host.UseSerilog();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CentrasContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddRazorPages()
.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
/* Enable support for localized DataAnnotations validation 
   messages. 
   NB: this works in .NET 7.0
 */
.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (_, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(Res).GetTypeInfo().Assembly.FullName!);
        return factory.Create(nameof(Res), assemblyName.Name!);
    };
});
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

var app = builder.Build();
app.UseSession();
app.UseRequestLocalization(options);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
