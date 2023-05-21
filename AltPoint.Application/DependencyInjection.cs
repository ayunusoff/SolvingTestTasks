using AltPoint.Application.Common;
using AltPoint.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AltPoint.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();

            return services;
        }
    }
}
