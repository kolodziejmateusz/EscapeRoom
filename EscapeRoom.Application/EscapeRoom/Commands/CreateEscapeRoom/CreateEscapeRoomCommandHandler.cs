using AutoMapper;
using EscapeRoom.Application.ApplicationUser;
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
        private IUserContext _userContext;

        public CreateEscapeRoomCommandHandler(IEscapeRoomRepository escapeRoomRepository, IMapper mapper, IUserContext userContext)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateEscapeRoomCommand request, CancellationToken cancellationToken)
        {
            var escapeRoom = _mapper.Map<Domain.Entities.EscapeRoom>(request);
            escapeRoom.EncodeName();
            escapeRoom.CreatedById = _userContext.GetCurrentUser().Id;
            await _escapeRoomRepository.Create(escapeRoom);

            return Unit.Value;
        }
    }
}
