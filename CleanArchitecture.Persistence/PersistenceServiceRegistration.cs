
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Persistence.DataBaseContext;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CleanArchitectureDBContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CleanArchitectureConnectionString"));
        });

        //Agregar implementacion de repositorios 
        //Implementacion GenericRepository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //Implementaciones de repositorios individuales
        //Ejemplo
        //services.AddScoped(IExampleRepository, ExampleRepository);

        return services;
    }
}
