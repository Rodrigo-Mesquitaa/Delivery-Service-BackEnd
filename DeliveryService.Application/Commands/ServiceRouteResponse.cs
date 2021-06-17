namespace DeliveryService.Application.Commands
{
    public class ServiceRouteResponse

    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ServiceRouteResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
