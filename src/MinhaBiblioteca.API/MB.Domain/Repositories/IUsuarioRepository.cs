using MB.Core.Data;
using MB.Domain.Entities;

namespace MB.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task Cadastrar(Usuario usuario);
        Task Atualizar(Usuario usuario);
    }
}
