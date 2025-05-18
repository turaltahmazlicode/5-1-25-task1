using _5_1_25_task1.BL.Services.Concretes;
using _5_1_25_task1.DAL.Contexts;
using _5_1_25_task1.DAL.Models;
using _5_1_25_task1.DAL.Repositories.Abstactions;
using _5_1_25_task1.DAL.Repositories.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1.MVC;

public static class ServiceImplementations
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddScoped<IRepository<Department>, Repository<Department>>();

        services.AddScoped<DepartmentService>();

        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {

        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
    }
}
