using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes_Car_Brand_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_Brand_Model",
                table: "Cars",
                columns: new[] { "Brand", "Model" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_Brand_Model",
                table: "Cars");
        }
    }
}
