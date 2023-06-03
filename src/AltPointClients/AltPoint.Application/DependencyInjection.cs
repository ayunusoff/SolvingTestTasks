using AltPoint.Application.Common;
using AltPoint.Application.DTOs;
using AltPoint.Application.Mapping;
using AltPoint.Application.Services;
using AltPoint.Application.Validations;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AltPoint.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ClientDTO>, ClientValidator>();
            services.AddScoped<IValidator<ClientWithSpouseDTO>, ClientWithSpouseValidator>();

            services.AddTransient<IClientService, ClientService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClientMap());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
