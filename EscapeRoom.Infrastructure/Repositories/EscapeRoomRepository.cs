using EscapeRoom.Domain.Interfaces;
using EscapeRoom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Domain.Entities.EscapeRoom>> GetAll()
        => await _dbContext.EscapeRooms.ToListAsync();

        public Task<Domain.Entities.EscapeRoom?> GetByName(string name)
        => _dbContext.EscapeRooms.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
