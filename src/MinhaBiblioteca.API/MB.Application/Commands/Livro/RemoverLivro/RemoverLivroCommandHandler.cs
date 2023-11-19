using MB.Core.Communication;
using MB.Core.Communication.Handler;
using MB.Domain.Repositories;

namespace MB.Application.Commands.Livro.RemoverLivro
{
    public class RemoverLivroCommandHandler : CommandHandler<RemoverLivroCommand, bool>
    {
        private readonly ILivroRepository _livroRepository;

        public RemoverLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public override async Task<RequestResponse<bool>> Handle(RemoverLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return new RequestResponse<bool>(false, message.ValidationResult);

            var livro = await _livroRepository.ObterLivroPorId(message.LivroId);

            _livroRepository.Remover(livro);

            await _livroRepository.UnitOfWork.Commit();

            return new RequestResponse<bool>(true, message.ValidationResult);
        }
    }
}
