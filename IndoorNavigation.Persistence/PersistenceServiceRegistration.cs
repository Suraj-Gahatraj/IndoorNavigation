using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Domain.Entities;
using IndoorNavigation.Persistence.Repositories;
using IndoorNavigation.Persistence.Repositories.EntityRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IndoorNavigationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IndoorNavigationConnectionString")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IndoorNavigationDbContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ISiteRepository), typeof(SiteRepository));

            return services;
        }
    }
}
