using EscapeRoom.Application.ApplicationUser;
using EscapeRoom.Application.EscapeRoom.Commands.CreateEscapeRoom;
using EscapeRoom.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(CreateEscapeRoomCommand));

            services.AddAutoMapper(typeof(EscapeRoomMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateEscapeRoomCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
