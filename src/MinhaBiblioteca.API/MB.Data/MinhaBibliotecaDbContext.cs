using MB.Core.Data;
using MB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MB.Data
{
    public class MinhaBibliotecaDbContext : DbContext, IUnitOfWork
    {
        public MinhaBibliotecaDbContext(DbContextOptions<MinhaBibliotecaDbContext> options) : base(options)
        {

        }

        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MinhaBibliotecaDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
