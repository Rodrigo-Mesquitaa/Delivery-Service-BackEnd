using DeliveryService.Application.Core;
using MediatR;

namespace DeliveryService.Application.Commands
{
    public class UpdateRoute : IRequest<Response>
    {
        public int Id { get; private set; }
        public int Time { get; private set; }
        public int Cost { get; private set; }
        public int ServiceOriginId { get; private set; }
        public int ServiceDestinationId { get; private set; }

        public UpdateRoute(int id, int time, int cost, int serviceOriginId, int serviceDestinationId)
        {
            Id = id;
            Time = time;
            Cost = cost;
            ServiceOriginId = serviceOriginId;
            ServiceDestinationId = serviceDestinationId;
        }

    }
}