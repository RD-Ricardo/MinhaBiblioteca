using MediatR;

namespace MB.Core.Communication.Handler
{
    public abstract class CommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, RequestResponse<TResponse>> where TCommand : Command<TResponse>
    {
        public abstract Task<RequestResponse<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
