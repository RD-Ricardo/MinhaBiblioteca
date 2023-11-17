using MB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Data.EntitiesConfigutations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(l => l.Autor)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(l => l.Isbn)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(l => l.AnoPublicacao)
                   .IsRequired();
        }
    }
}
