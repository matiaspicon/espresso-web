using Microsoft.EntityFrameworkCore;
using proyecto_final_webconfig.Data;
using proyecto_final_webconfig.Repository;
using proyecto_final_webconfig.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EspressoContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddTransient<IEventsRepository, EventsRepository>();
builder.Services.AddTransient<IEventsService, EventsService>();
builder.Services.AddTransient<IDevicesRepository, DevicesRepository>();
builder.Services.AddTransient<IDevicesService, DevicesService>();


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
