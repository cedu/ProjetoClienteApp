using ProjetoClienteApp.Domain.Interfaces.Repositories;
using ProjetoClienteApp.Domain.Interfaces.Services;
using ProjetoClienteApp.Domain.Services;
using ProjetoClienteApp.Infra.Data.Repositories;

namespace ProjetoClienteApp.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IClienteDomainService, ClienteDomainService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
