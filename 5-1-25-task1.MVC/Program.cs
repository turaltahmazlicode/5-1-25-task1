using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _5_1_25_task1.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequiredLength = 8;
            opt.Lockout.AllowedForNewUsers = true;
            opt.Lockout.MaxFailedAccessAttempts = 3;
        }).AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

        //builder.Services.AddScoped<IGenericRepository<ModelName>, GenericRepository<ModelName>>();

        //builder.Services.AddScoped<NonGenericService>();

        var app = builder.Build();

        app.UseStaticFiles();

        app.MapControllerRoute(name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


        app.Run();
    }
}
