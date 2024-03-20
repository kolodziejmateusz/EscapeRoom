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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.EscapeRoom>()
                .OwnsOne(c => c.AddressDetails);
        }
    }
}
