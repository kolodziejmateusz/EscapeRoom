using EscapeRoom.Application.ApplicationUser;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoomReview.Commands
{
    public class CreateEscapeRoomReviewCommandHandler : IRequestHandler<CreateEscapeRoomReviewCommand>
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;
        private readonly IUserContext _userContext;
        private readonly IEscapeRoomReviewRepository _escapeRoomReviewRepository;

        public CreateEscapeRoomReviewCommandHandler(IEscapeRoomRepository escapeRoomRepository, IUserContext userContext, IEscapeRoomReviewRepository escapeRoomReviewRepository)
        {
            _escapeRoomRepository = escapeRoomRepository;
            _userContext = userContext;
            _escapeRoomReviewRepository = escapeRoomReviewRepository;
        }
        public async Task<Unit> Handle(CreateEscapeRoomReviewCommand request, CancellationToken cancellationToken)
        {
            var escapeRoom = await _escapeRoomRepository.GetByEncodedName(request.EscapeRoomEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null;

            if (!isEditable)
            {
                return Unit.Value;
            }

            var escapeRoomReview = new Domain.Entities.EscapeRoomReview()
            {
                ReviewerName = request.ReviewerName,
                Review = request.Review,
                StarRating = request.StarRating,
                EscapeRoomId = escapeRoom.Id
            };

            await _escapeRoomReviewRepository.Create(escapeRoomReview);

            return Unit.Value;
        }
    }
}
