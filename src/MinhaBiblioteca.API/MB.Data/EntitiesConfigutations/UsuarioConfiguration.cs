using MB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Data.EntitiesConfigutations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Email)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(u => u.Nome)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
