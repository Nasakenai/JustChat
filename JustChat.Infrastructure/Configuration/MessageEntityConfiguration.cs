using JustChat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustChat.Infrastructure.Configuration
{
    internal class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Timestamped);
            builder.HasOne(e => e.Sender)
                .WithMany(e => e.SentMessages)
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ChatRoom)
                .WithMany(e => e.Messages)
                .HasForeignKey(e => e.ChatRoomId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
