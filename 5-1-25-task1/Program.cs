using _5_1_25_task1.DAL;
using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt
                => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
