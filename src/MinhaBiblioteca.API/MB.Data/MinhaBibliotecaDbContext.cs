using MB.Core.Data;
using MB.Core.DomainObjects;
using MB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace MB.Data
{
    public class MinhaBibliotecaDbContext : DbContext, IUnitOfWork
    {
        public MinhaBibliotecaDbContext(DbContextOptions<MinhaBibliotecaDbContext> options) : base(options) {}
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MinhaBibliotecaDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entidade in ChangeTracker.Entries<Entity>().Where(c => c.State == EntityState.Added))
                entidade.Entity.DataCriacao = DateTime.Now;

            foreach (var entidade in ChangeTracker.Entries<Entity>().Where(c => c.State == EntityState.Modified))
                entidade.Entity.DataAtualizacao = DateTime.Now;

            return await SaveChangesAsync() > 0;
        }
    }
}
