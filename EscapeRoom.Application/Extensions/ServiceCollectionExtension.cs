using EscapeRoom.Application.EscapeRoom;
using EscapeRoom.Application.Mappings;
using EscapeRoom.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEscapeRoomService, EscapeRoomService>();

            services.AddAutoMapper(typeof(EscapeRoomMappingProfile));

            services.AddValidatorsFromAssemblyContaining<EscapeRoomDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
