using AutoMapper;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Queries.GetAllEscapeRooms
{
    public class GetAllEscapeRoomsQueryHandler : IRequestHandler<GetAllEscapeRoomsQuery, IEnumerable<EscapeRoomDto>>
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;
        private IMapper _mapper;

        public GetAllEscapeRoomsQueryHandler(IEscapeRoomRepository escapeRoomRepository, IMapper mapper)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EscapeRoomDto>> Handle(GetAllEscapeRoomsQuery request, CancellationToken cancellationToken)
        {
            var escapeRooms = await _escapeRoomRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<EscapeRoomDto>>(escapeRooms);
            return dtos;
        }
    }
}
