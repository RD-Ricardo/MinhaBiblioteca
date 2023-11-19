using FluentValidation;
using MB.Core.Communication;

namespace MB.Application.Commands.Livro.CadastrarLivro
{
    public class CadastrarLivroCommand : Command<bool>
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Isbn { get; private set; }
        public DateTime AnoPublicacao { get; private set; }
        public CadastrarLivroCommand(string titulo, string autor, string isbn, DateTime anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
        }

        public override bool IsValid()
        {
            var validacaoResult = new CadastrarLivroCommandValidator().Validate(this);
            return validacaoResult.IsValid;
        }

        private class CadastrarLivroCommandValidator : AbstractValidator<CadastrarLivroCommand>
        {
            public CadastrarLivroCommandValidator()
            {
                RuleFor(l => l.Titulo)
                    .NotEmpty()
                    .NotNull();


                RuleFor(l => l.Autor)
                    .NotEmpty()
                    .NotNull();

                RuleFor(l => l.Isbn)
                    .NotEmpty()
                    .NotNull();
            }
        }
    }
}
