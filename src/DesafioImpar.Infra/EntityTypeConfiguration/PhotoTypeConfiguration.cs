using DesafioImpar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioImpar.Infra.EntityTypeConfiguration
{
    public class PhotoTypeConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
            => builder.HasKey(k => k.Id);
    }
}
