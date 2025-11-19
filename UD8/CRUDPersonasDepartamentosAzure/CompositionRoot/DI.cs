using Data.Repositories;
using Domain.Interfaces;
using Domain.Repos;
using Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoute(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetListaPersonas, RepoPersonas>();
            services.AddScoped<IGetListaPersonasUseCase, DefGetListaPersonasUseCase>();

            return services;
        }
    }
}
