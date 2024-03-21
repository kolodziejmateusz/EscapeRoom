using EscapeRoom.Application.ApplicationUser;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Commands.EditEscapeRoom
{
    public class EditEscapeRoomCommandHandler : IRequestHandler<EditEscapeRoomCommand>
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;
        private readonly IUserContext _userContext;

        public EditEscapeRoomCommandHandler(IEscapeRoomRepository escapeRoomRepository, IUserContext userContext)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditEscapeRoomCommand request, CancellationToken cancellationToken)
        {
            var escapeRoom = await _escapeRoomRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && escapeRoom.CreatedById == user.Id;

            if (!isEditable)
            {
                return Unit.Value;
            }

            escapeRoom.Description = request.Description;

            escapeRoom.AddressDetails.PhoneNumber = request.PhoneNumber;
            escapeRoom.AddressDetails.Street = request.Street;
            escapeRoom.AddressDetails.City = request.City;
            escapeRoom.AddressDetails.PostalCode = request.PostalCode;

            await _escapeRoomRepository.Commit();

            return Unit.Value;
        }
    }
}
