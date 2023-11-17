using MediatR;

namespace MB.Core.Communication.Handler
{
    public abstract class QueryHandler<TQuery, TReponse> : IRequestHandler<TQuery, RequestResponse<TReponse>> where TQuery : Query<TReponse>
    {
        public abstract Task<RequestResponse<TReponse>> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
