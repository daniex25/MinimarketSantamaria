using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using MinimarketSantamaria.Areas.Identity.Data.AccesoDatos;
using MinimarketSantamaria.Areas.Identity.Data.Interface;
using MinimarketSantamaria.Data;
using System.Globalization;
using static MinimarketSantamaria.Data.MinimarketSantamariaContext;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MinimarketSantamariaContextConnection") ?? throw new InvalidOperationException("Connection string 'MinimarketSantamariaContextConnection' not found.");;

//Globalizacion
builder.Services.AddDbContext<MinimarketSantamariaContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resource";
});

builder.Services.AddMvc(options =>
{
    options.CacheProfiles.Add("Default", new CacheProfile
    {
        Duration = 6,
        Location = ResponseCacheLocation.Any
    });

    options.CacheProfiles.Add("Never", new CacheProfile
    {
        Duration = 86,
        Location = ResponseCacheLocation.None
    });
})
.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);



//Roles 
builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() //se agrega esto
    .AddEntityFrameworkStores<MinimarketSantamariaContext>();

builder.Services.AddAuthorization(
    options => options.AddPolicy(
        "GerenteSantamaria",
        policy => policy.RequireRole("Gerente")));
builder.Services.AddAuthorization(
    options => options.AddPolicy(
        "AsistenteSantamaria",
        policy => policy.RequireRole("Asistente")));
builder.Services.AddAuthorization(
    options => options.AddPolicy(
        "AnonimoSantamaria",
        policy => policy.RequireRole("Anonimo")));
builder.Services.AddAuthorization(
    options => options.AddPolicy(
        "EmpleadoSantamaria",
        policy => policy.RequireRole("Empleado")));
builder.Services.AddAuthorization(
    options => options.AddPolicy(
        "GerenteAsistenteSantamaria",
        policy => policy.RequireRole("Gerente", "Asistente")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inyección de Dependencias
builder.Services.AddSingleton<ProductoIDA, ProductoDA>();
builder.Services.AddSingleton<SucursalIDA, SucursalDA>();
builder.Services.AddSingleton<UnidadMedidaIDA, UnidadMedidaDA>();
builder.Services.AddSingleton<VentasIDA, VentasDA>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//Globalizacion
var cultures = new List<CultureInfo>();
cultures.Add(new CultureInfo("en-US"));
cultures.Add(new CultureInfo("es-PE"));
cultures.Add(new CultureInfo("fr-FR"));
var requestLocations = new RequestLocalizationOptions
{
    SupportedCultures = cultures,
    SupportedUICultures = cultures,
    DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US")
};
app.UseRequestLocalization(requestLocations);



app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
