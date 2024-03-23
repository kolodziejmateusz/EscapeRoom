using MediatR;

namespace EscapeRoom.Application.EscapeRoomReview.Commands
{
    public class CreateEscapeRoomReviewCommand : EscapeRoomReviewDto, IRequest
    {
        public string EscapeRoomEncodedName { get; set; } = default!;
    }
}
