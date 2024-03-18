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

        public EditEscapeRoomCommandHandler(IEscapeRoomRepository escapeRoomRepository)
        {
            _escapeRoomRepository = escapeRoomRepository;
        }
        public async Task<Unit> Handle(EditEscapeRoomCommand request, CancellationToken cancellationToken)
        {
            var escapeRoom = await _escapeRoomRepository.GetByEncodedName(request.EncodedName!);

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
