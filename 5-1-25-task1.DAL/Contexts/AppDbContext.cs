using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1.DAL.Contexts;
public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Doctor>()
            .HasOne(d => d.Department)
            .WithMany(e => e.Doctors)
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Department>()
            .HasIndex(e => e.Title)
            .IsUnique(true);
    }
}
