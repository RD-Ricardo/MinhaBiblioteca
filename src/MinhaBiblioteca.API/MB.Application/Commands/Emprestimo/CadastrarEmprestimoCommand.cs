using FluentValidation;
using MB.Core.Communication;

namespace MB.Application.Commands.Emprestimo
{
    public class CadastrarEmprestimoCommand : Command<bool>
    {
        public DateTime DataDevolucao { get; private set; }
        public bool Ativo { get; private set; }
        public int UsuarioId { get; private set; }
        public int LivroId { get; private set; }
        public CadastrarEmprestimoCommand(DateTime dataDevolucao, bool ativo, int usuarioId, int livroId)
        {
            DataDevolucao = dataDevolucao;
            Ativo = ativo;
            UsuarioId = usuarioId;
            LivroId = livroId;
        }
        public override bool IsValid()
        {
            var validacao = new CadastrarEmprestimoCommandValidator().Validate(this);
            return validacao.IsValid;
        }

        private class CadastrarEmprestimoCommandValidator : AbstractValidator<CadastrarEmprestimoCommand>
        {
            public CadastrarEmprestimoCommandValidator()
            {
                RuleFor(e => e.Ativo)
                       .NotNull()
                       .NotEqual(false);
            }
        }
    }
}
