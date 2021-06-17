using DeliveryService.Application.Commands;
using DeliveryService.Application.Core;
using DeliveryService.Application.Domain.Interfaces;
using DeliveryService.Application.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeliveryRoute.Application.Handlers
{
	public class RouteHandler :
	IRequestHandler<CreateRoute, Response>,
	IRequestHandler<UpdateRoute, Response>,
	IRequestHandler<DeleteRoute, Response>
	{
		private readonly IRouteRepository routeRepository;

		public RouteHandler(IRouteRepository routeRepository)
		{
			this.routeRepository = routeRepository;
		}

		public async Task<Response> Handle(CreateRoute request, CancellationToken cancellationToken)
		{
			var Route = new Route(request.ServiceDestinationId, request.ServiceOriginId, request.Time, request.Cost);

			await routeRepository.InsertAsync(Route);

			return new Response("Rota criada com sucesso!");
		}

		public async Task<Response> Handle(UpdateRoute request, CancellationToken cancellationToken)
		{
			var Route = new Route(request.Id, request.ServiceDestinationId, request.ServiceOriginId, request.Time, request.Cost);

			await routeRepository.UpdateAsync(Route);

			return new Response("Rota atualizada com sucesso!");
		}

		public async Task<Response> Handle(DeleteRoute request, CancellationToken cancellationToken)
		{
			await routeRepository.DeleteAsync(request.Id);

			return new Response("Rota excluida com sucesso!");
		}


	}
}