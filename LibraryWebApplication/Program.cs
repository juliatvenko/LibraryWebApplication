using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryWebApplication.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LibraryWebApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryWebApplicationContext") ?? throw new InvalidOperationException("Connection string 'LibraryWebApplicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the visit counter service.
builder.Services.AddSingleton<LibraryWebApplication.Services.VisitCounterService>();

// Add services required for using session state
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // You can set Timeouts and other parameters here.
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

// It's important to call UseSession after UseRouting and before UseEndpoints
app.UseSession();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

namespace LibraryWebApplication.Services
{
    public class VisitCounterService
    {
        private int _visitCount = 0;

        public int VisitCount
        {
            get
            {
                _visitCount++;
                return _visitCount;
            }
        }
    }
}

