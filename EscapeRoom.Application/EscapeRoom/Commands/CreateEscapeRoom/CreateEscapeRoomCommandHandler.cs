using AutoMapper;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Commands.CreateEscapeRoom
{
    public class CreateEscapeRoomCommandHandler : IRequestHandler<CreateEscapeRoomCommand>
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;
        private IMapper _mapper;

        public CreateEscapeRoomCommandHandler(IEscapeRoomRepository escapeRoomRepository, IMapper mapper)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateEscapeRoomCommand request, CancellationToken cancellationToken)
        {
            var escapeRoom = _mapper.Map<Domain.Entities.EscapeRoom>(request);
            escapeRoom.EncodeName();
            await _escapeRoomRepository.Create(escapeRoom);

            return Unit.Value;
        }
    }
}
