
using System.Collections.Generic;

namespace MB.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<RequestResponse<TResponse>> SendCommandAsync<TCommand, TResponse>(TCommand command) where TCommand : Command<TResponse>;
        Task<RequestResponse<TResponse>> SendQueryAsync<TQuery, TResponse>(TQuery query) where TQuery : Query<TResponse>;
        Task PublisherEvent<TEvent>(TEvent evento)  where TEvent : Event;
    }
}
