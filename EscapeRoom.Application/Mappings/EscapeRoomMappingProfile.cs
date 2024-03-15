using AutoMapper;
using EscapeRoom.Application.EscapeRoom;
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
        public EscapeRoomMappingProfile()
        {
            CreateMap<EscapeRoomDto, Domain.Entities.EscapeRoom>()
                .ForMember(e => e.AddressDetails, opt => opt.MapFrom(src => new EscapeRoomAddressDetails()
                {
                    PhoneNumber = src.PhoneNumber,
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                }));
        }
    }
}
