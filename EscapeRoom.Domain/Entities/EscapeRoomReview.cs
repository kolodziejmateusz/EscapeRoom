using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Domain.Entities
{
    public class EscapeRoomReview
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; } = default!;
        public string? Review { get; set; }
        public StarRating StarRating { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public int EscapeRoomId { get; set; } = default!;
        public EscapeRoom EscapeRoom { get; set; } = default!;
    }

    public enum StarRating
    {
        OneStar = 1,
        TwoStars = 2,
        ThreeStars = 3,
        FourStars = 4,
        FiveStars = 5
    }
}
