using MB.Core.Communication;
using MB.Core.Communication.Handler;
using MB.Domain.Repositories;
using System.Runtime.CompilerServices;

namespace MB.Application.Commands.Livro.CadastrarLivro
{
    public class CadastrarLivroCommandHandler : CommandHandler<CadastrarLivroCommand, bool>
    {
        private readonly ILivroRepository _livroRepository;

        public CadastrarLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public override async Task<RequestResponse<bool>> Handle(CadastrarLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return new RequestResponse<bool>(false, message.ValidationResult);


            var livro = new MB.Domain.Entities.Livro(message.Titulo, 
                                                     message.Autor, 
                                                     message.Isbn, 
                                                     message.AnoPublicacao);

            _livroRepository.Cadastrar(livro);

            await _livroRepository.UnitOfWork.Commit();

            return new RequestResponse<bool>(true, message.ValidationResult);
        }
    }
}
