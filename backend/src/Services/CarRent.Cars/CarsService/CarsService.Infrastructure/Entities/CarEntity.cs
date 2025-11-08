using CarsService.Infrastructure.Enums;

namespace CarsService.Infrastructure.Entities
{
    public class CarEntity
    {
        public Guid Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public CarType CarType { get; set; }
        public SteeringType Steering { get; set; }
        public int Capacity { get; set; }
        public int Gasoline { get; set; }
        public int ReleaseYear { get; set; }
        public ICollection<string> ImageUrls { get; set; } = [];
    }
}
