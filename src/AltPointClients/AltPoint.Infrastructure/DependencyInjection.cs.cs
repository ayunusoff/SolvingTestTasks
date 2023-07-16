using AltPoint.Application.Common;
using AltPoint.Domain.Interfaces;
using AltPoint.Infrastructure.Persistance.EFCore;
using AltPoint.Infrastructure.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AltPoint.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEfCorePersistance(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AltPointContext>(options =>
                options.UseNpgsql(config.GetConnectionString("Db"), b => b.MigrationsAssembly("AltPoint.Infrastructure")));
            services.AddScoped<IClientRepo, ClientRepo>();
            //services.AddScoped<IProducer, RabbitMQProducer>();
            return services;
        }
    }
}
