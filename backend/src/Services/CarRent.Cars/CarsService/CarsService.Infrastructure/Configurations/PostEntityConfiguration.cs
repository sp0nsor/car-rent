using CarsService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsService.Infrastructure.Configurations
{
    public class PostEntityConfiguration
        : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CarId)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(p => p.DiscountPercentage)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.AverageRating)
                .IsRequired()
                .HasPrecision(3, 2)
                .HasDefaultValue(0.0f);

            builder.Property(p => p.PricePerDay)
                .IsRequired()
                .HasPrecision(10, 2)
                .HasDefaultValue(0.0f);

            builder.HasOne(p => p.Car)
                .WithOne()
                .HasForeignKey<PostEntity>(p => p.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.CreatedAt)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder.Property(p => p.UpdatedAt)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder.HasIndex(p => p.CarId)
                .IsUnique();
        }
    }
}
