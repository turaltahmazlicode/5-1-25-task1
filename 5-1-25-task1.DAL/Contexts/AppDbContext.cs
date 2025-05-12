using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace _5_1_25_task1.DAL.Contexts;
public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
