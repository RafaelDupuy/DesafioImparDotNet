using DesafioImpar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioImpar.Infra.Context
{
    public class ImparContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public ImparContext(DbContextOptions contextOptions)
            : base(contextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ImparContext)));
    }
}
