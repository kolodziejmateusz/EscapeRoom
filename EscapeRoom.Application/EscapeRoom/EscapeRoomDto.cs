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
        public string Name { get; set; } = default!;
        [Display(Name = "Opis")]
        public string? Description { get; set; }
        [Display(Name = "Numer telefonu")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Ulica")]
        public string? Street { get; set; }
        [Display(Name = "Miasto")]
        public string? City { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string? PostalCode { get; set; }

        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
    }
}
