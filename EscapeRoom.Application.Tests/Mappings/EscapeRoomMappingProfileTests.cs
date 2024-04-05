using Xunit;
using EscapeRoom.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using EscapeRoom.Application.ApplicationUser;
using AutoMapper;
using EscapeRoom.Application.EscapeRoom;
using FluentAssertions;

namespace EscapeRoom.Application.Mappings.Tests
{
    public class EscapeRoomMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapEscapeRoomDtoToEscapeRoom()
        {
            // arrange
            var userContext = new Mock<IUserContext>();
            userContext.Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new List<string> { "Moderator" }));

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new EscapeRoomMappingProfile(userContext.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new EscapeRoomDto
            {
                PhoneNumber = "555555555",
                Street = "Długa 15",
                PostalCode  = "32-222",
                City = "Kraków"
            };

            // act
            var result = mapper.Map<Domain.Entities.EscapeRoom>(dto);

            // assert
            result.Should().NotBeNull();
            result.AddressDetails.Should().NotBeNull();
            result.AddressDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.AddressDetails.Street.Should().Be(dto.Street);
            result.AddressDetails.PostalCode.Should().Be(dto.PostalCode);
            result.AddressDetails.City.Should().Be(dto.City);
        }

        [Fact()]
        public void MappingProfile_ShouldMapEscapeRoomToEscapeRoomDto()
        {
            // arrange
            var userContext = new Mock<IUserContext>();
            userContext.Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("14", "test@test.com", new List<string> { "Moderator" }));

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new EscapeRoomMappingProfile(userContext.Object)));

            var mapper = configuration.CreateMapper();

            var escapeRoom = new Domain.Entities.EscapeRoom
            {
                Id = 13,
                CreatedById = "14",
                AddressDetails = new Domain.Entities.EscapeRoomAddressDetails
                {
                    PhoneNumber = "222444222",
                    Street = "Szeroka 19",
                    PostalCode = "31-222",
                    City = "Kraków"
                }
            };

            // act
            var result = mapper.Map<EscapeRoomDto>(escapeRoom);

            // assert
            result.IsEditable.Should().BeTrue();
            result.PhoneNumber.Should().Be(escapeRoom.AddressDetails.PhoneNumber);
            result.Street.Should().Be(escapeRoom.AddressDetails.Street);
            result.PostalCode.Should().Be(escapeRoom.AddressDetails.PostalCode);
            result.City.Should().Be(escapeRoom.AddressDetails.City);
        }
    }
}