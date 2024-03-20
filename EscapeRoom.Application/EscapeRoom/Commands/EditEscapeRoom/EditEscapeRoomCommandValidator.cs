using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Commands.EditEscapeRoom
{
    public class EditEscapeRoomCommandValidator : AbstractValidator<EditEscapeRoomCommand>
    {
        public EditEscapeRoomCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Opis jest wymagany.")
                .MinimumLength(20).WithMessage("Opis musi mieć minimum 20 znaki.")
                .MaximumLength(255).WithMessage("Opis może mieć maksymalnie 255 znaków.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Numer telefonu jest wymagany.")
                .MinimumLength(8).WithMessage("Numer musi mieć minimum 8 znaków.")
                .MaximumLength(15).WithMessage("Numer może mieć maksymalnie 15 znaków.");

            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Ulica jest wymagana.")
                .MinimumLength(3).WithMessage("Ulica musi mieć minimum 3 znaki.")
                .MaximumLength(20).WithMessage("Ulica może mieć maksymalnie 20 znaków.");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Miasto jest wymagane.")
                .MinimumLength(3).WithMessage("Miasto musi mieć minimum 3 znaki.")
                .MaximumLength(20).WithMessage("Miasto może mieć maksymalnie 20 znaków.");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("Kod pocztowy jest wymagany.")
                .MinimumLength(6).WithMessage("Kod pocztowy musi mieć minimum 6 znaki.")
                .MaximumLength(7).WithMessage("Kod pocztowy może mieć maksymalnie 7 znaków.");
        }
    }
}
