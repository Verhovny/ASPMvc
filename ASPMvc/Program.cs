using ASPMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Подключение базы данных SQL Server
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(connection));
            //builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(connection));
            //builder.Services.AddDbContext<DataContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 30))));
            //builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connection));



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
}