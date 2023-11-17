using MB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Data.EntitiesConfigutations
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(e => e.LivroId)
                   .IsRequired();

            builder.Property(e => e.UsuarioId)
                   .IsRequired();
        }
    }
}
