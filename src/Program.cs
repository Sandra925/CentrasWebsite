using Centras.db;
using Centras.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddDbContext<CentrasContext>(options =>
    options.UseSqlite("Data Source=C:\\Users\\K203082\\Desktop\\Centras\\Centras\\Centras\\db\\centras.db"));
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
    new CultureInfo( "en" ),
    new CultureInfo( "lt" )
};
var options = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
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
