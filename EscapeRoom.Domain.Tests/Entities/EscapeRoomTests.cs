using Xunit;
using EscapeRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace EscapeRoom.Domain.Entities.Tests
{
    public class EscapeRoomTests
    {
        [Fact()]
        public void EncodeName_ShouldSetEncodeName()
        {
            // arrange 
            var escaperoom = new EscapeRoom();
            escaperoom.Name = "   Bardzo Straszny Dom W Lesie    ";

            // act
            escaperoom.EncodeName();

            // assert
            escaperoom.EncodedName.Should().Be("bardzo-straszny-dom-w-lesie");
        }

        [Fact()]
        public void EncodeName_ShouldThrowException_WhenIsNull()
        {
            // arrange 
            var escaperoom = new EscapeRoom();

            // act
            Action action = () => escaperoom.EncodeName();

            // assert
            action.Invoking(a => a.Invoke())
                .Should().Throw<NullReferenceException>();
        }
    }
}