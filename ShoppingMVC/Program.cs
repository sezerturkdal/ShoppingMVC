using Microsoft.EntityFrameworkCore;
using ShoppingMVC.Controllers;
using ShoppingMVC.Models;
using ShoppingMVC.Repos;

namespace ShoppingMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ShoppingDbContext>(options =>

                {
                    var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
                    options.UseSqlServer(connectionString);
                }
                //options.UseInMemoryDatabase("ShoppingDb")
        );

        builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();



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
    }
}

