using Domain.Interfaces;

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
