using System;
using System.Threading.Tasks;
using DeliveryService.Application.Handlers;
using Moq;
using Xunit;
using DeliveryService.Application.Commands;
using System.Threading;
using DeliveryService.Application.Core;
using DeliveryService.Application.Domain.Interfaces;

namespace DeliveryService.Tests.Handlers
{
    public class ServiceHandlerTests
    {
        private ServiceHandler _handler;

        private Mock<IServiceRepository> serviceRepository = new Mock<IServiceRepository>();
        private Mock<IRouteRepository> routeRepository = new Mock<IRouteRepository>();

        public ServiceHandlerTests()
        {
            _handler = new ServiceHandler(serviceRepository.Object, routeRepository.Object);
        }

        [Fact]
        public async Task CreateServiceRoute()
        {
            var comand = new CreateService("Service test 01");

            var result = await _handler.Handle(comand, GetCancelationToken(TimeSpan.FromSeconds(1)).Token);

            Assert.NotNull(result);

            var objectResult = result as Response;
            Assert.NotNull(objectResult);

            Assert.Equal("Serviço criado com sucesso!", objectResult.Result);
        }

        [Fact]
        public async Task UpdateServiceRoute()
        {
            var message = $"Service test 01 updated {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";

            var comand = new UpdateService(1, message);

            var result = await _handler.Handle(comand, GetCancelationToken(TimeSpan.FromSeconds(1)).Token);

            Assert.NotNull(result);

            var objectResult = result as Response;

            Assert.NotNull(objectResult);

            Assert.Equal("Serviço atualizado com sucesso!", objectResult.Result);

        }


        [Fact]
        public async Task DeleteServiceRoute()
        {
            var comand = new DeleteService(1);

            var result = await _handler.Handle(comand, GetCancelationToken(TimeSpan.FromSeconds(1)).Token);

            Assert.NotNull(result);

            var objectResult = result as Response;
            Assert.NotNull(objectResult);

            Assert.Equal("Serviço excluido com sucesso!", objectResult.Result);
        }

        [Fact]
        public async Task GetShortestPath()
        {
            // arrange         
            //serviceRepository.Setup(m => m.Query())
            //                               .Returns<IQueryable<Service>>(p => p);

            //routeRepository.Setup(m => m.Query())
            //.Returns<IQueryable<Route>>(p => p);

            //var serviceDbSetMock = Builder<Service>.CreateListOfSize(9).Build().ToAsyncDbSetMock();
            //serviceRepository.Setup(m => m.Query()).Returns(serviceDbSetMock.Object);

            //var routeDbSetMock = Builder<Route>.CreateListOfSize(11).Build().ToAsyncDbSetMock();
            //routeRepository.Setup(m => m.Query()).Returns(routeDbSetMock.Object);

            _handler = new ServiceHandler(serviceRepository.Object, routeRepository.Object);

            var comand = new GetShortestPath(1, 2);

            var result = await _handler.Handle(comand, GetCancelationToken(TimeSpan.FromSeconds(1)).Token);

            Assert.NotNull(result);

            var objectResult = result as Response;
            Assert.NotNull(objectResult);

        }

        private CancellationTokenSource GetCancelationToken(TimeSpan time)
        {

            CancellationTokenSource source = new CancellationTokenSource();

            source.CancelAfter(time);

            return source;
        }
    }
}
