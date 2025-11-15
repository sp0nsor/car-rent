using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CarType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TransmissionType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SeatsCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    DrivingRange = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Power = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ImageUrls = table.Column<string>(type: "character varying(1300)", maxLength: 1300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    DiscountPercentage = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    AverageRating = table.Column<float>(type: "real", precision: 3, scale: 2, nullable: false, defaultValue: 0f),
                    PricePerDay = table.Column<float>(type: "real", precision: 10, scale: 2, nullable: false, defaultValue: 0f),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CarId",
                table: "Posts",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
