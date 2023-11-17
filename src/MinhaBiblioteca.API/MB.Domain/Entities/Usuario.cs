using MB.Core.Data;
using MB.Core.DomainObjects;

namespace MB.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        //EF
        protected Usuario() { }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
