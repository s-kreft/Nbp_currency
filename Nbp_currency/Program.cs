using Nbp_currency.Service;
using Nbp_currency;
using Nbp_currency.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<INbpService, NbpService>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NbpContext>(options =>
{
    var connectionString = "server=localhost;user=root;password=root;database=nbp_currency";

    var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

    options.UseMySql(connectionString, serverVersion)
    .EnableDetailedErrors();
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
