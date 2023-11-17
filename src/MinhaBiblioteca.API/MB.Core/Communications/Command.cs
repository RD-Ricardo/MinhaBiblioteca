using FluentValidation.Results;
using MediatR;

namespace MB.Core.Communication
{
    public abstract class Command<TReponse> : IRequest<RequestResponse<TReponse>>
    {
        public DateTime TimeStamp { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
        protected Command()
        {
              ValidationResult = new ValidationResult();   
        }
    }
}
