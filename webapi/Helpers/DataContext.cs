
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
        modelBuilder.Entity<Tarefa>()
            .Property(m=>m.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Tarefa>()
            .Property(m => m.NomeTarefa).IsRequired();
        modelBuilder.Entity<Tarefa>()
            .Property(m => m.DataInicio).IsRequired();
        modelBuilder.Entity<Tarefa>()
            .Property(m => m.Terminado).IsRequired();
            
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}
