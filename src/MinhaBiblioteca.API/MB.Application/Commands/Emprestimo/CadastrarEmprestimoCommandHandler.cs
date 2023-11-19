using MB.Core.Communication;
using MB.Core.Communication.Handler;
using MB.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Commands.Emprestimo
{
    public class CadastrarEmprestimoCommandHandler : CommandHandler<CadastrarEmprestimoCommand, bool>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public CadastrarEmprestimoCommandHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

       public override async Task<RequestResponse<bool>> Handle(CadastrarEmprestimoCommand message, CancellationToken cancellationToken)
       {
            if (!message.IsValid()) return new RequestResponse<bool>(false, message.ValidationResult);


            var emprestimo = new MB.Domain.Entities.Emprestimo(message.DataDevolucao,
                                                     message.Ativo,
                                                     message.UsuarioId,
                                                     message.LivroId);

            _emprestimoRepository.Cadastrar(emprestimo);

            await _emprestimoRepository.UnitOfWork.Commit();

            return new RequestResponse<bool>(true, message.ValidationResult);
        }
    }
}
