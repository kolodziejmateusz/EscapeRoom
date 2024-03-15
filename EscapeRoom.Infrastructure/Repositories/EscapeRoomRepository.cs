using EscapeRoom.Domain.Interfaces;
using EscapeRoom.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Infrastructure.Repositories
{
    internal class EscapeRoomRepository : IEscapeRoomRepository
    {
        private readonly EscapeRoomDbContext _dbContext;

        public EscapeRoomRepository(EscapeRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.EscapeRoom escapeRoom)
        {
            _dbContext.Add(escapeRoom);
            await _dbContext.SaveChangesAsync();
        }
    }
}
