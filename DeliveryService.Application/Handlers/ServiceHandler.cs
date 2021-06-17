using DeliveryService.Application.Commands;
using DeliveryService.Application.Core;
using DeliveryService.Application.Domain.Interfaces;
using DeliveryService.Application.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeliveryService.Application.Handlers
{
	public class ServiceHandler :
	IRequestHandler<CreateService, Response>,
	IRequestHandler<UpdateService, Response>,
	IRequestHandler<DeleteService, Response>,
	IRequestHandler<GetShortestPath, Response>
	{
		private readonly IServiceRepository serviceRepository;
		private readonly IRouteRepository routeRepository;

		public ServiceHandler(IServiceRepository serviceRepository, IRouteRepository routeRepository)
		{
			this.serviceRepository = serviceRepository;
			this.routeRepository = routeRepository;
		}

		public async Task<Response> Handle(CreateService request, CancellationToken cancellationToken)
		{
			var Service = new Service(request.Name);

			await serviceRepository.InsertAsync(Service);

			return new Response("Serviço criado com sucesso!");
		}

		public async Task<Response> Handle(UpdateService request, CancellationToken cancellationToken)
		{
			var Service = new Service(request.Id, request.Name);

			await serviceRepository.UpdateAsync(Service);

			return new Response("Serviço atualizado com sucesso!");
		}

		public async Task<Response> Handle(DeleteService request, CancellationToken cancellationToken)
		{
			await serviceRepository.DeleteAsync(request.Id);

			return new Response("Serviço excluido com sucesso!");
		}

		public Task<Response> Handle(GetShortestPath request, CancellationToken cancellationToken)
		{
			var response = new Response();
			var result = serviceRepository.Query().ToList();

			if (!result.Any(x => x.Id == request.StartId))
			{
				response.AddError("Initial Service does not exist.");

				return Task.FromResult(response);
			}

			if (!result.Any(x => x.Id == request.DestinationId))
			{
				response.AddError("End Service does not exist.");

				return Task.FromResult(response);
			}

			result.ForEach(x =>
			{
				x.AddRoutes(routeRepository.Query().Where(r => r.ServiceOriginId == x.Id).ToList());
			});

			var path = new List<int>() { request.StartId };

			SearchPath(request.StartId, request.DestinationId, ref path, ref result);

			return Task.FromResult(new Response(path));
		}


		private void SearchPath(int currentId, int destinationId, ref List<int> path, ref List<Service> nodes)
		{
			if (currentId != destinationId)
			{
				Service service = nodes.First(x => x.Id == currentId);

				int weight = int.MaxValue;
				int? auxId = null;

				foreach (var p in service.Routes)
				{
					if (p.Time < weight)
					{
						weight = p.Time;
						auxId = p.ServiceDestinationId;
					}
				}

				if (auxId.HasValue)
					path.Add(auxId.Value);

				SearchPath(auxId.Value, destinationId, ref path, ref nodes);
			}
		}
	}
}