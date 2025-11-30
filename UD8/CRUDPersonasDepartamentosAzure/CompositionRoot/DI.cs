using Data.Repos;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using UseCases;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoute(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepoPersonas, RepoPersonas>();
            services.AddScoped<IRepoDepartamentos, RepoDepartamentos>();
            services.AddScoped<IPersonasUseCase, PersonasUseCase>();
            services.AddScoped<IDepartamentosUseCase, DepartamentosUseCase>();

            return services;
        }
    }
}
