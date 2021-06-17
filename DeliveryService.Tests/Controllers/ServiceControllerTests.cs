using DeliveryService.API.Controllers;
using DeliveryService.Application.Domain.Interfaces;
using MediatR;
using Moq;

namespace DeliveryService.Tests.Controllers
{
    public class ServiceControllerTests
    {
        private ServiceController _controller;

        private Mock<IServiceRepository> serviceRepository = new Mock<IServiceRepository>();
        private Mock<IRouteRepository> routeRepository = new Mock<IRouteRepository>();
        private Mock<IMediator> _mediatrMock = new Mock<IMediator>();

        public ServiceControllerTests()
        {
            _controller = new ServiceController(_mediatrMock.Object, serviceRepository.Object);
        }

    }
}
