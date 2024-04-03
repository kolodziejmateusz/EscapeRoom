using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoomReview.Commands.CreateEscapeRoomReview
{
    public class CreateEscapeRoomReviewCommandValidator : AbstractValidator<CreateEscapeRoomReviewCommand>
    {
        public CreateEscapeRoomReviewCommandValidator()
        {
            RuleFor(s => s.ReviewerName).NotEmpty().NotNull().WithMessage("Nazwa recenzenta jest wymagana.");
            RuleFor(s => s.Review).NotEmpty().NotNull().WithMessage("Recenzja jest wymagana.");
            RuleFor(s => s.StarRating).NotEmpty().NotNull().WithMessage("Ilość gwiazdek jest wymagana.");
            RuleFor(s => s.EscapeRoomEncodedName).NotEmpty().NotNull();
        }
    }
}
