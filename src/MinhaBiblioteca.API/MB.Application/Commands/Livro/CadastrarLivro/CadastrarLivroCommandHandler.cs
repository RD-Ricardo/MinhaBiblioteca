using MB.Core.Communication;
using MB.Core.Communication.Handler;

namespace MB.Application.Commands.Livro.CadastrarLivro
{
    public class CadastrarLivroCommandHandler : CommandHandler<CadastrarLivroCommand, bool>
    {

        public CadastrarLivroCommandHandler()
        {

        }

        public override Task<RequestResponse<bool>> Handle(CadastrarLivroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
