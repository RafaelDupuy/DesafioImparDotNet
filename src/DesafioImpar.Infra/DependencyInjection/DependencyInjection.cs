using DesafioImpar.Infra.Context;
using DesafioImpar.Infra.Interfaces;
using DesafioImpar.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
            services.MigrateDatabase();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPhotoRepository,PhotoRepository>();
            services.AddTransient<ICardRepository,CardRepository>();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<ImparContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

        private static void MigrateDatabase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<ImparContext>();
            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
                context.Database.Migrate();
        }
    }
}
