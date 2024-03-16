using AutoMapper;
using EscapeRoom.Application.EscapeRoom;
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
        private IMapper _mapper;

        public EscapeRoomService(IEscapeRoomRepository escapeRoomRepository, IMapper mapper)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _mapper = mapper;
        }
        public async Task Create(EscapeRoomDto escapeRoomDto)
        {
            var escapeRoom = _mapper.Map<Domain.Entities.EscapeRoom>(escapeRoomDto);
            escapeRoom.EncodeName();
            await _escapeRoomRepository.Create(escapeRoom);
        }

        public async Task<IEnumerable<EscapeRoomDto>> GetAll()
        {
            var escapeRooms = await _escapeRoomRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<EscapeRoomDto>>(escapeRooms);
            return dtos;
        }
    }
}
