using DesafioImpar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioImpar.Infra.EntityTypeConfiguration
{
    internal class CardTypeConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Status).HasMaxLength(100);
            builder.HasOne(p => p.Photo).WithOne(c => c.Card).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
