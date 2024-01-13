
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServces(this IServiceCollection services, IConfiguration configuration)
    {
        //Aqui se haria la implementacion de las interfaces que tengan funcionalidades externas
        //Ejemplo, en caso de tener una interfaz que consulta a otra API, o un servicio de correo
        // la implementacion de estos estaria dentro de este proyecto
        //Ejemplo ⬇️
        //services.AddTransient<IMailService, MailService>();
        return services;
    }
}
