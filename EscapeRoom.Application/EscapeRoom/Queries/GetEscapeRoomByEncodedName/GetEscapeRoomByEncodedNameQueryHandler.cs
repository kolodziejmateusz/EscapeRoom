using AutoMapper;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Queries.GetEscapeRoomByEncodedName
{
    public class GetEscapeRoomByEncodedNameQueryHandler : IRequestHandler<GetEscapeRoomByEncodedNameQuery, EscapeRoomDto>
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;
        private readonly IMapper _mapper;

        public GetEscapeRoomByEncodedNameQueryHandler(IEscapeRoomRepository escapeRoomRepository, IMapper mapper)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _mapper = mapper;
        }

        public async Task<EscapeRoomDto> Handle(GetEscapeRoomByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var escapeRoom = await _escapeRoomRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<EscapeRoomDto>(escapeRoom);

            return dto;
        }
    }
}
