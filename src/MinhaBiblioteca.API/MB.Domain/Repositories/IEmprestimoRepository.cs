using MB.Core.Data;
using MB.Domain.Entities;

namespace MB.Domain.Repositories
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Task DevolverLivro(int emprestimoId);
        Task<IEnumerable<Emprestimo>> ObterTodos();
        Task<IEnumerable<Emprestimo>> ObterTodosAtivos();
    }
}
