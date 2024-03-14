using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Infrastructure.Persistence
{
    public class EscapeRoomDbContext : DbContext
    {
        public EscapeRoomDbContext(DbContextOptions<EscapeRoomDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Domain.Entities.EscapeRoom> EscapeRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.EscapeRoom>()
                .OwnsOne(c => c.AddressDetails);
        }
    }
}
