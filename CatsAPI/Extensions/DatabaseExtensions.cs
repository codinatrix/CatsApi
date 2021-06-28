using Cats.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatsAPI;
using System.Reflection;

namespace Cats.API.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddCatsApiContext(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<CatApiContext>(opt =>
                {
                    opt.UseSqlServer(
                        connectionString,
                        x =>
                        {
                            x.MigrationsAssembly(typeof(Startup)
                                .GetTypeInfo()
                                .Assembly
                                .GetName().Name);
                        });
                });
        }
    }
}
