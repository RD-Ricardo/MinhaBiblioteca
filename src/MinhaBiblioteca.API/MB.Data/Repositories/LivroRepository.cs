using MB.Core.Data;
using MB.Domain.Entities;
using MB.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MB.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly MinhaBibliotecaDbContext _minhaBibliotecaDbContext;

        public LivroRepository(MinhaBibliotecaDbContext minhaBibliotecaDbContext)
        {
            _minhaBibliotecaDbContext = minhaBibliotecaDbContext;
        }

        public IUnitOfWork UnitOfWork => _minhaBibliotecaDbContext;

        public void Cadastrar(Livro livro)
        {
             _minhaBibliotecaDbContext.Livros.Add(livro);
        }
        public void Remover(Livro livro)
        {
            _minhaBibliotecaDbContext.Livros.Remove(livro);
        }

        public async Task<Livro> ObterLivroPorId(int livroId)
        {
           return await _minhaBibliotecaDbContext.Livros.SingleOrDefaultAsync(x => x.Id == livroId);
        }

        public async Task<IEnumerable<Livro>> ObterTodos()
        {
            return await _minhaBibliotecaDbContext.Livros.ToListAsync();
        }

        public void Dispose()
        {
            _minhaBibliotecaDbContext?.Dispose();
        }
    }
}
