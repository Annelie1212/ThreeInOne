using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreeInOne.Migrations
{
    /// <inheritdoc />
    public partial class Changedshapesdatacolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShapeData",
                table: "ShapeData");

            migrationBuilder.RenameTable(
                name: "ShapeData",
                newName: "ShapesData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShapesData",
                table: "ShapesData",
                column: "ShapesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShapesData",
                table: "ShapesData");

            migrationBuilder.RenameTable(
                name: "ShapesData",
                newName: "ShapeData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShapeData",
                table: "ShapeData",
                column: "ShapesId");
        }
    }
}
