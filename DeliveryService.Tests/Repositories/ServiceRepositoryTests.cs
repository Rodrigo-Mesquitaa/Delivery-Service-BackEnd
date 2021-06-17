using DeliveryService.Data.SQL.Repositories;
using Moq;

namespace DeliveryService.Tests.Repositories
{
    public class ServiceRepositoryTests
	{
		private Mock<ServiceRepository> _repository;

		public ServiceRepositoryTests()
		{
			_repository = new Mock<ServiceRepository>();

			Initialise();
		}

		private void Initialise()
		{


		}

	}
}
