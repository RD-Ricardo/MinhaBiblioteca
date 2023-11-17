using FluentValidation.Results;
using MediatR;

namespace MB.Core.Communication
{
    public abstract class Query<TResponse> : IRequest<RequestResponse<TResponse>>
    {
        public DateTime Timestamp { get; private set; } = DateTime.Now;
        public ValidationResult ValidationResult { get; private set; }
        public abstract bool IsValid();
        public Query()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
