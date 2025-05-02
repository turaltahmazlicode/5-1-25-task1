using _5_1_25_task1.Models;
using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<HeaderDoctor> HeaderDoctors { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
}
