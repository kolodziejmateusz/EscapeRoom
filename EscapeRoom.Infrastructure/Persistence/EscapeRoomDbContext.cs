using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoom.Infrastructure.Persistence
{
    public class EscapeRoomDbContext : IdentityDbContext
    {
        public EscapeRoomDbContext(DbContextOptions<EscapeRoomDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Domain.Entities.EscapeRoom> EscapeRooms { get; set; }
        public DbSet<Domain.Entities.EscapeRoomReview> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.EscapeRoom>()
                .OwnsOne(c => c.AddressDetails);

            modelBuilder.Entity<Domain.Entities.EscapeRoom>()
                .HasMany(c => c.Reviews)
                .WithOne(s => s.EscapeRoom)
                .HasForeignKey(s => s.EscapeRoomId);
        }
    }
}
