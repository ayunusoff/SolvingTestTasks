using AltPoint.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AltPoint.Infrastructure.Persistance.EFCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEfCorePersistance(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AltPointContext>(options =>
                options.UseNpgsql(config.GetConnectionString("Db"), b => b.MigrationsAssembly("AltPoint.Infrastructure")));
            services.AddScoped<IClientRepo, ClientRepo>();
            return services;
        }
    }
}
