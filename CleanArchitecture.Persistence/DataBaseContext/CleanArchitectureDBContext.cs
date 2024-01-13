
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.DataBaseContext;

public class CleanArchitectureDBContext : DbContext
{
    public CleanArchitectureDBContext(DbContextOptions<CleanArchitectureDBContext> options) : base(options){ }

    //Agregar DbSets debajo ⬇️
    //  Ejemplo
    //public DbSet<Entity> Entity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchitectureDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
