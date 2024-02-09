using JustChat.Application.Interfaces;
using JustChat.Infrastructure.Persistence;
using JustChat.Infrastructure.Repository;
using JustChat.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JustChat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AuthConnection"));
            });

            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<AuthDbContext>();

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChatManagerService, ChatManagerService>();

            return services;
        }
    }
}
