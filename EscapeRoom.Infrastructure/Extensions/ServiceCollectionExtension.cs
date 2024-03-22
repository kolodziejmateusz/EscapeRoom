using EscapeRoom.Domain.Interfaces;
using EscapeRoom.Infrastructure.Persistence;
using EscapeRoom.Infrastructure.Repositories;
using EscapeRoom.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EscapeRoom.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EscapeRoomDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("EscapeRoom")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EscapeRoomDbContext>();

            services.AddScoped<EscapeRoomSeeder>();
            services.AddScoped<IEscapeRoomRepository, EscapeRoomRepository>();
            services.AddScoped<IEscapeRoomReviewRepository, EscapeRoomReviewRepository>();

        }
    }
}
