using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Configurations;

namespace Infrastructure.DataAccess
{
    internal class ApplicationContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
