using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // services.AddDbContext<DataContext>(options =>
            // {
            //     options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            // });

            return services;
        }
    }
}