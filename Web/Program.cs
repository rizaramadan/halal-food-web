using Web.Data;
using Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connStr));

builder.Services.AddScoped<IRestoRepo, AppDbContext>();
builder.Services.AddScoped<RestoFinder>();

// Add services to the container.
var mvcBuilder = builder.Services.AddControllersWithViews();
if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Search}/{action=Index}/{id?}");

app.Run();
