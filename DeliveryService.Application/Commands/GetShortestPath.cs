using DeliveryService.Application.Core;
using MediatR;

namespace DeliveryService.Application.Commands
{
	public class GetShortestPath : IRequest<Response>
	{
		public int StartId { get; private set; }

		public int DestinationId { get; private set; }


		public GetShortestPath(int startId, int destinationId)
		{
			StartId = startId;

			DestinationId = destinationId;

		}

	}
}