using CarsService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarsService.Infrastructure.Configurations
{
    public class CarEntityConfiguration
        : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.CarType)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(c => c.TransmissionType)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(c => c.Color)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.SeatsCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(c => c.DrivingRange)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(c => c.ReleaseYear)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(c => c.Power)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(c => c.ImageUrls)
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                )
                .HasMaxLength(1300);
        }
    }
}
