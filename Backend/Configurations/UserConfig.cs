using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(500).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(500).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Role).HasMaxLength(500).IsRequired();
        }
    }
}