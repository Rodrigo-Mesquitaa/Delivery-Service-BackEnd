using DeliveryService.Application.Core;
using MediatR;

namespace DeliveryService.Application.Commands
{
    public class DeleteRoute : IRequest<Response>
    {
        public int Id { get; private set; }

        public DeleteRoute(int id)
        {
            Id = id;
        }

    }
}