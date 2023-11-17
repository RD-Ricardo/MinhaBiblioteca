using MB.Core.Data;
using MB.Domain.Entities;

namespace MB.Domain.Repositories
{
    public interface ILivroRepository : IRepository<Livro>
    {
        void Cadastrar(Livro livro);
        void Remover(Livro livro);
        Task<IEnumerable<Livro>> ObterTodos();
        Task<Livro> ObterLivroPorId(int livroId);
    }
}
