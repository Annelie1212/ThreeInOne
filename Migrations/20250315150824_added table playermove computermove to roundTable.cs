using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreeInOne.Migrations
{
    /// <inheritdoc />
    public partial class addedtableplayermovecomputermovetoroundTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Player",
                table: "RockPaperScissorsRoundData",
                newName: "PlayerMove");

            migrationBuilder.RenameColumn(
                name: "Move",
                table: "RockPaperScissorsRoundData",
                newName: "ComputerMove");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerMove",
                table: "RockPaperScissorsRoundData",
                newName: "Player");

            migrationBuilder.RenameColumn(
                name: "ComputerMove",
                table: "RockPaperScissorsRoundData",
                newName: "Move");
        }
    }
}
