using AutoMapper;
using EscapeRoom.Application.ApplicationUser;
using EscapeRoom.Application.EscapeRoom;
using EscapeRoom.Application.EscapeRoom.Commands.EditEscapeRoom;
using EscapeRoom.Application.EscapeRoomReview;
using EscapeRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.Mappings
{
    public class EscapeRoomMappingProfile : Profile
    {
        public EscapeRoomMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<EscapeRoomDto, Domain.Entities.EscapeRoom>()
                .ForMember(e => e.AddressDetails, opt => opt.MapFrom(src => new EscapeRoomAddressDetails()
                {
                    PhoneNumber = src.PhoneNumber,
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                }));

            CreateMap<Domain.Entities.EscapeRoom, EscapeRoomDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.AddressDetails.PhoneNumber))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.AddressDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.AddressDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.AddressDetails.PostalCode));

            CreateMap<EscapeRoomDto, EditEscapeRoomCommand>();

            CreateMap<Domain.Entities.EscapeRoomReview, EscapeRoomReviewDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator"))));

            CreateMap<EscapeRoomReviewDto, Domain.Entities.EscapeRoomReview>();
        }
    }
}
