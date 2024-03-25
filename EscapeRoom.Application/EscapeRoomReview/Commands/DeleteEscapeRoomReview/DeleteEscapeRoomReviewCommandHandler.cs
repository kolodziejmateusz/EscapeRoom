using EscapeRoom.Application.ApplicationUser;
using EscapeRoom.Domain.Entities;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoomReview.Commands.DeleteEscapeRoomReview
{
    public class DeleteEscapeRoomReviewCommandHandler : IRequestHandler<DeleteEscapeRoomReviewCommand>
    { 
        private readonly IUserContext _userContext;
        private readonly IEscapeRoomReviewRepository _escapeRoomReviewRepository;

        public DeleteEscapeRoomReviewCommandHandler(IUserContext userContext, IEscapeRoomReviewRepository escapeRoomReviewRepository)
        {
            _userContext = userContext;
            _escapeRoomReviewRepository = escapeRoomReviewRepository;
        }

        public async Task<Unit> Handle(DeleteEscapeRoomReviewCommand request, CancellationToken cancellationToken)
        {
            int id = int.Parse(request.Id);
            var escapeRoomReview = await _escapeRoomReviewRepository.GetById(id);
            var user = _userContext.GetCurrentUser();

            var isEditable = user != null && (escapeRoomReview.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            await _escapeRoomReviewRepository.Delete(id);

            return Unit.Value;
        }
    }
}
