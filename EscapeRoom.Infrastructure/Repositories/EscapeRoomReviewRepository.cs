using EscapeRoom.Domain.Entities;
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
    public class EscapeRoomReviewRepository : IEscapeRoomReviewRepository
    {
        private readonly EscapeRoomDbContext _dbContext;

        public EscapeRoomReviewRepository(EscapeRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(EscapeRoomReview escapeRoomReview)
        {
            _dbContext.Reviews.Add(escapeRoomReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EscapeRoomReview>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Reviews
            .Where(s => s.EscapeRoom.EncodedName == encodedName)
            .ToListAsync();
    }
}
