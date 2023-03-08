using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connetcionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(connetcionString);
            });
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationContext>());

            return services;
        }
    }
}
