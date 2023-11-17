using MB.Core.Data;
using MB.Core.DomainObjects;

namespace MB.Domain.Entities
{
    public class Emprestimo : Entity, IAggregateRoot
    {
        public DateTime DataDevolucao { get; private set; }
        public bool Ativo { get; private set; }
        public Emprestimo(DateTime dataDevolucao, bool ativo,  int usuarioId, int livroId)
        {
            DataDevolucao = dataDevolucao;
            UsuarioId = usuarioId;
            LivroId = livroId;
            Ativo = ativo;
        }

        //EF
        protected Emprestimo() { }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; set; }
        public int LivroId { get; private set; }
        public Livro Livro { get; set; }
        public bool EmAtraso => DateTime.Now.Date > DataDevolucao.Date;
        public void DesativarEmprestimo()
        {
            Ativo = false;
        }
    }
}
