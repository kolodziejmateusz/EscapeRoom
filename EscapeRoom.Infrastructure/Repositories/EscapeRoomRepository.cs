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
    public class EscapeRoomRepository : IEscapeRoomRepository
    {
        private readonly EscapeRoomDbContext _dbContext;

        public EscapeRoomRepository(EscapeRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.EscapeRoom escapeRoom)
        {
            _dbContext.Add(escapeRoom);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(string encodedName)
        {
            Domain.Entities.EscapeRoom? escapeRoom = await _dbContext.EscapeRooms.FirstAsync(c => c.EncodedName == encodedName);
            if (escapeRoom != null)
            {
                _dbContext.EscapeRooms.Remove(escapeRoom);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Domain.Entities.EscapeRoom>> GetAll()
        => await _dbContext.EscapeRooms.ToListAsync();

        public async Task<Domain.Entities.EscapeRoom> GetByEncodedName(string encodedName)
        => await _dbContext.EscapeRooms.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.EscapeRoom?> GetByName(string name)
        => _dbContext.EscapeRooms.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
