using MB.Core.Data;
using MB.Domain.Entities;
using MB.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MB.Data.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly MinhaBibliotecaDbContext _minhaBibliotecaDbContext;
        public EmprestimoRepository(MinhaBibliotecaDbContext minhaBibliotecaDbContext)
        {
            _minhaBibliotecaDbContext = minhaBibliotecaDbContext;
        }

        public IUnitOfWork UnitOfWork => _minhaBibliotecaDbContext;

        public void Atualizar(Emprestimo emprestimo)
        {
            _minhaBibliotecaDbContext.Update(emprestimo);
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            _minhaBibliotecaDbContext.Add(emprestimo);
        }

        public Task DevolverLivro(int emprestimoId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _minhaBibliotecaDbContext?.Dispose();
        }

        public async Task<IEnumerable<Emprestimo>> ObterTodos()
        {
            return await _minhaBibliotecaDbContext.Emprestimos.ToListAsync();
        }

        public async Task<IEnumerable<Emprestimo>> ObterTodosAtivos()
        {
            return await _minhaBibliotecaDbContext.Emprestimos.Where(x => x.Ativo == true).ToListAsync();
        }
    }
}
