using Aspo.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aspo.Core.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Conversation> Conversations { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasOne(au => au.Creator)
                        .WithMany(c => c.Conversations)
                        .HasForeignKey(au => au.CreatorId)
                        .OnDelete(DeleteBehavior.Cascade);
            });
                

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(au => au.Sender)
                        .WithMany(m => m.Messages)
                        .HasForeignKey(au => au.SenderId)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Conversation)
                        .WithMany(m => m.Messages)
                        .HasForeignKey(c => c.ConversationId)
                        .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasOne(au => au.User)
                        .WithOne(p => p.Participant)
                        .HasForeignKey<Participant>(au => au.UserId);

                entity.HasOne(c => c.Conversation)
                        .WithMany(p => p.Participants)
                        .HasForeignKey(c => c.ConversationId)
                        .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
