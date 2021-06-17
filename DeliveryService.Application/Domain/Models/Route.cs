namespace DeliveryService.Application.Domain.Models
{
    public class Route
    {
        public int Id { get; private set; }
        public int Time { get; private set; }
        public int Cost { get; private set; }

        public int ServiceOriginId { get; private set; }

        public int ServiceDestinationId { get; private set; }

        public Route(
            int id,
            int serviceDestinationId,
            int serviceOriginId,
            int time,
            int cost)
        {
            Id = id;
            Time = time;
            Cost = cost;

            ServiceDestinationId = serviceDestinationId;
            ServiceOriginId = serviceOriginId;
        }

        public Route(
            int serviceDestinationId,
            int serviceOriginId,
            int time,
            int cost)
        {
            Time = time;
            Cost = cost;

            ServiceDestinationId = serviceDestinationId;
            ServiceOriginId = serviceOriginId;
        }
    }
}