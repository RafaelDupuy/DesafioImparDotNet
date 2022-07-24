using DesafioImpar.Infra.Context;
using DesafioImpar.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioImpar.Infra.DependencyInjection
{
    public static class DependencyInjection
    {

        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<PhotoRepository>();
            services.AddTransient<CardRepository>();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<ImparContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
    }
}
