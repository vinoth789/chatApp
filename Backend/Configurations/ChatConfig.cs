using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations
{
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId);
            builder.Property(x => x.CreatedTimestamp);
            builder.Property(x => x.Message).HasMaxLength(500).IsRequired();

        }
    }
}