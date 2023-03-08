using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name).IsRequired().HasMaxLength(15);
            builder.Property(u => u.Surname).IsRequired().HasMaxLength(15);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(30);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Username).IsRequired().HasMaxLength(15);
            builder.HasIndex(u => u.Username).IsUnique();
        }
    }
}
