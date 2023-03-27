
using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.Helpers;
public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Task>()
            .Property(m => m.id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Entities.Task>()
            .Property(m => m.taskName).IsRequired();
        modelBuilder.Entity<Entities.Task>()
            .Property(m => m.startDate).IsRequired();
        modelBuilder.Entity<Entities.Task>()
            .Property(m => m.finished).IsRequired();
            
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Entities.Task> Tasks { get; set; }
}
