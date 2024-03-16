using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom
{
    public class EscapeRoomDto
    {
        [Required(ErrorMessage ="Nazwa jest wymagana.")]
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public string? EncodedName { get; set; }
    }
}
