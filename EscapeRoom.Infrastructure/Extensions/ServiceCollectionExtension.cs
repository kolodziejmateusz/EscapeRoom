using EscapeRoom.Domain.Interfaces;
using EscapeRoom.Infrastructure.Persistence;
using EscapeRoom.Infrastructure.Repositories;
using EscapeRoom.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EscapeRoomDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("EscapeRoom")));

            services.AddScoped<EscapeRoomSeeder>();
            services.AddScoped<IEscapeRoomRepository, EscapeRoomRepository>();
        }
    }
}
