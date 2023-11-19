using FluentValidation;
using MB.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Commands.Livro.RemoverLivro
{
    public class RemoverLivroCommand : Command<bool>
    {
        public int LivroId { get; private set; }

        public RemoverLivroCommand(int livroId)
        {
            LivroId = livroId;
        }

        public override bool IsValid()
        {
            var validacaoResult = new RemvoerLivroCommandValidator().Validate(this);
            return validacaoResult.IsValid;
        }

        private class RemvoerLivroCommandValidator : AbstractValidator<RemoverLivroCommand>
        {
            public RemvoerLivroCommandValidator()
            {
                RuleFor(l => l.LivroId)
                    .NotNull()
                    .NotEmpty()
                    .NotEqual(0);
            }
        }
    }
}
