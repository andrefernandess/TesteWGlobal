using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TesteWGlobal.Application.Helpers;
using TesteWGlobal.Application.Interfaces;
using TesteWGlobal.Application.Services;
using TesteWGlobal.Repository.Context;
using TesteWGlobal.Repository.Interfaces;
using TesteWGlobal.Repository.Repositories;

namespace TesteWGlobal.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new TesteWGlobalProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

        }
    }
}
