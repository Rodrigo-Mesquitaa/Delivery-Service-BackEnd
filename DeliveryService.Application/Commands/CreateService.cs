using DeliveryService.Application.Core;
using MediatR;

namespace DeliveryService.Application.Commands
{
    public class CreateService : IRequest<Response>
    {
        public string Name { get; private set; }

        public CreateService(string name)
        {
            Name = name;
        }

    }
}