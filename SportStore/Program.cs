using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Interfaces;
using SportStore.Models;


using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace SportStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddMvc();
            
            // объект создается один раз для каждой зависимости
            //builder.Services.AddSingleton<IRepository, DataRepository>();

            builder.Services.AddTransient<IRepository, DataRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();


            // Подключение базы данных SQL Server
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            builder.Services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = connection;
                options.SchemaName = "dbo";
                options.TableName = "SessionData";
            });


            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "SportStore.Session";
                options.IdleTimeout = System.TimeSpan.FromHours(48);
                options.Cookie.HttpOnly = false;
            });


            var app = builder.Build();
            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.UseSession();

            app.Run();
        }
    }
}