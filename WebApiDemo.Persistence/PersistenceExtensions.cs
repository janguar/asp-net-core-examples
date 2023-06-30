using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            //services.AddDbContext<ApplicationContext>(options =>
            //options.UseSqlServer(
            //    Configuration.GetConnectionString("DefaultConnection"),
            //    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            return services;
        }
    }
}
