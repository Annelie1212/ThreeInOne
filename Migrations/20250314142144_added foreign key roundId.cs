using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreeInOne.Migrations
{
    /// <inheritdoc />
    public partial class addedforeignkeyroundId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "RockPaperScissorsRoundData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RockPaperScissorsRoundData_MatchId",
                table: "RockPaperScissorsRoundData",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_RockPaperScissorsRoundData_RockPaperScissorsMatchData_MatchId",
                table: "RockPaperScissorsRoundData",
                column: "MatchId",
                principalTable: "RockPaperScissorsMatchData",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RockPaperScissorsRoundData_RockPaperScissorsMatchData_MatchId",
                table: "RockPaperScissorsRoundData");

            migrationBuilder.DropIndex(
                name: "IX_RockPaperScissorsRoundData_MatchId",
                table: "RockPaperScissorsRoundData");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "RockPaperScissorsRoundData");
        }
    }
}
