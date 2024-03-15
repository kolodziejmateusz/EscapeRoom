using EscapeRoom.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.Services
{
    public class EscapeRoomService : IEscapeRoomService
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;

        public EscapeRoomService(IEscapeRoomRepository escapeRoomRepository)
        {
            _escapeRoomRepository = escapeRoomRepository;
        }
        public async Task Create(Domain.Entities.EscapeRoom escapeRoom)
        {
            escapeRoom.EncodeName();
            await _escapeRoomRepository.Create(escapeRoom);
        }
    }
}
