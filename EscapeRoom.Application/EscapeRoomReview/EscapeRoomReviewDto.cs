using EscapeRoom.Domain.Entities;

namespace EscapeRoom.Application.EscapeRoomReview
{
    public class EscapeRoomReviewDto
    {
        public string ReviewerName { get; set; } = default!;
        public string? Review { get; set; }
        public StarRating StarRating { get; set; }

        public bool IsEditable { get; set; }
    }
}
