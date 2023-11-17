using MediatR;

namespace MB.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task PublisherEvent<TEvent>(TEvent evento) where TEvent : Event
        {
            return _mediator.Publish(evento);
        }

        public Task<RequestResponse<TResponse>> SendCommandAsync<TCommand, TResponse>(TCommand command) where TCommand : Command<TResponse>
        {
            return _mediator.Send(command);
        }

        public Task<RequestResponse<TResponse>> SendQueryAsync<TQuery, TResponse>(TQuery query) where TQuery : Query<TResponse>
        {
            return _mediator.Send(query);
        }
    }
}
