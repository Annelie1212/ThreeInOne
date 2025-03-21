using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreeInOne.Migrations
{
    /// <inheritdoc />
    public partial class addedtriangleanglecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AngleInDegrees",
                table: "ShapesData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AngleInDegrees",
                table: "ShapesData");
        }
    }
}
