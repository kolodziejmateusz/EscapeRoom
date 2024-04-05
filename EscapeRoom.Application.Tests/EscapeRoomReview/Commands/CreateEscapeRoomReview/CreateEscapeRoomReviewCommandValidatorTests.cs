using Xunit;
using EscapeRoom.Application.EscapeRoomReview.Commands.CreateEscapeRoomReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace EscapeRoom.Application.EscapeRoomReview.Commands.CreateEscapeRoomReview.Tests
{
    public class CreateEscapeRoomReviewCommandValidatorTests
    {
        [Fact()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            // arrange
            var validator = new CreateEscapeRoomReviewCommandValidator();
            var command = new CreateEscapeRoomReviewCommand()
            {
                ReviewerName = "Jan Batory",
                Review = "Bardzo świetny pokuj",
                StarRating = Domain.Entities.StarRating.FourStars,
                EscapeRoomEncodedName = "bardzo-straszny-dom"
            };

            // act
            var result = validator.TestValidate(command);

            // assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validate_WithInvalidCommand_ShouldHaveValidationErrors()
        {
            // arrange
            var validator = new CreateEscapeRoomReviewCommandValidator();
            var command = new CreateEscapeRoomReviewCommand()
            {
                ReviewerName = "",
                Review = "",
                StarRating = Domain.Entities.StarRating.FourStars,
                EscapeRoomEncodedName = null!
            };

            // act
            var result = validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(c => c.ReviewerName);
            result.ShouldHaveValidationErrorFor(c => c.Review);
            result.ShouldHaveValidationErrorFor(c => c.EscapeRoomEncodedName);
        }
    }
}