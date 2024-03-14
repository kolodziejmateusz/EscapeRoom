using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Domain.Entities
{
    public class EscapeRoom
    {
        public required int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CratedAt { get; set; } = DateTime.UtcNow;
        public EscapeRoomAddressDetails AddressDetails { get; set; } = default!;

        public string EncodedName { get; private set; } = default!;

        public void EncodeName()
        {
            EncodedName = Name.ToLower().Replace(" ", "-");
        }
    }
}
