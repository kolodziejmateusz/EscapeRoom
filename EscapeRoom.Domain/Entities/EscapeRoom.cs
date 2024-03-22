using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Domain.Entities
{
    public class EscapeRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CratedAt { get; set; } = DateTime.Now;
        public EscapeRoomAddressDetails AddressDetails { get; set; } = default!;

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public string EncodedName { get; private set; } = default!;

        public List<EscapeRoomReview> Reviews { get; set; } = new();

        public void EncodeName()
        {
            EncodedName = Name.Trim().ToLower().Replace(" ", "-");
        }
    }
}
