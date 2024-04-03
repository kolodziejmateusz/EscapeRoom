using Xunit;
using EscapeRoom.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace EscapeRoom.Application.ApplicationUser.Tests
{
    public class CurrentUserTests
    {
        [Fact()]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue()
        {
            // arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });

            // act
            var isInRole = currentUser.IsInRole("Admin");
            var isInRole2 = currentUser.IsInRole("User");

            // assert
            isInRole.Should().BeTrue();
            isInRole2.Should().BeTrue();
        }

        [Fact()]
        public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
        {
            // arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });

            // act
            var isInRole = currentUser.IsInRole("Owner");
            var isInRole2 = currentUser.IsInRole("Moderator");

            // assert
            isInRole.Should().BeFalse();
            isInRole2.Should().BeFalse();
        }

        [Fact()]
        public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
        {
            // arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });

            // act
            var isInRole = currentUser.IsInRole("admin");
            var isInRole2 = currentUser.IsInRole("user");

            // assert
            isInRole.Should().BeFalse();
            isInRole2.Should().BeFalse();
        }
    }
}