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
        [MinLength(3, ErrorMessage = "Nazwa musi mieć minimum 3 znaki."), MaxLength(20, ErrorMessage = "Nazwa może mieć maksymalnie 20 znaków.")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Opis jest wymagany.")]
        [MinLength(20, ErrorMessage = "Opis musi mieć minimum 20 znaki."), MaxLength(255, ErrorMessage = "Opis może mieć maksymalnie 255 znaków.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Numer telefonu jest wymagany.")]
        [MinLength(8, ErrorMessage = "Numer musi mieć minimum 8 znaków."), MaxLength(13, ErrorMessage = "Numer może mieć maksymalnie 13 znaków.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Ulica jest wymagana.")]
        [MinLength(3, ErrorMessage = "Ulica musi mieć minimum 3 znaki."), MaxLength(20, ErrorMessage = "Ulica może mieć maksymalnie 20 znaków.")]
        public string? Street { get; set; }
        [Required(ErrorMessage = "Miasto jest wymagane.")]
        [MinLength(3, ErrorMessage = "Miasto musi mieć minimum 3 znaki."), MaxLength(20, ErrorMessage = "Miasto może mieć maksymalnie 20 znaków.")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany.")]
        [MinLength(6, ErrorMessage = "Kod pocztowy musi mieć minimum 6 znaki."), MaxLength(7, ErrorMessage = "Kod pocztowy może mieć maksymalnie 7 znaków.")]
        public string? PostalCode { get; set; }

        public string? EncodedName { get; set; }
    }
}
