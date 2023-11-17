using MB.Core.Data;
using MB.Core.DomainObjects;

namespace MB.Domain.Entities
{
    public class Livro : Entity, IAggregateRoot
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Isbn { get; private set; }
        public DateTime AnoPublicacao { get; private set; }
        public Livro(string titulo, string autor, string isbn, DateTime anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
        }

        //EF
        protected Livro() { }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
