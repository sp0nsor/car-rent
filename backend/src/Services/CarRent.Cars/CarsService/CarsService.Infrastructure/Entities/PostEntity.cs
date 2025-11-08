namespace CarsService.Infrastructure.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public CarEntity? Car { get; set; }
        public string Description { get; set; } = string.Empty;
        public int DiscountPercentage { get; set; }
        public float AverageRating { get; set; }
        public float PricePerDay { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
