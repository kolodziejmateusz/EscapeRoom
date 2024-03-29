﻿using AutoMapper;
using EscapeRoom.Application.ApplicationUser;
using EscapeRoom.Domain.Entities;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Commands.DeleteEscapeRoom
{
    public class DeleteEscapeRoomCommandHandler : IRequestHandler<DeleteEscapeRoomCommand>
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;
        private IUserContext _userContext;

        public DeleteEscapeRoomCommandHandler(IEscapeRoomRepository escapeRoomRepository, IUserContext userContext)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteEscapeRoomCommand request, CancellationToken cancellationToken)
        {
            var escapeRoom = await _escapeRoomRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (escapeRoom.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            await _escapeRoomRepository.Delete(request.EncodedName);

            return Unit.Value;

        }
    }
}
