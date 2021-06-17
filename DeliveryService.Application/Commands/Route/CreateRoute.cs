using DeliveryService.Application.Core;
using MediatR;

namespace DeliveryService.Application.Commands
{
	public class CreateRoute : IRequest<Response>
	{
		public int Time { get; private set; }
		public int Cost { get; private set; }
		public int ServiceOriginId { get; private set; }
		public int ServiceDestinationId { get; private set; }

		public CreateRoute(int time, int cost, int serviceOriginId, int serviceDestinationId)
		{
			Time = time;
			Cost = cost;
			ServiceOriginId = serviceOriginId;
			ServiceDestinationId = serviceDestinationId;
		}

	}
}