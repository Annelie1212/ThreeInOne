using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreeInOne.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatorData",
                columns: table => new
                {
                    CalculatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserValue1 = table.Column<double>(type: "float", nullable: false),
                    UserValue2 = table.Column<double>(type: "float", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatorData", x => x.CalculatorId);
                });

            migrationBuilder.CreateTable(
                name: "RockPaperScissorsMatchData",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Win = table.Column<int>(type: "int", nullable: false),
                    Loss = table.Column<int>(type: "int", nullable: false),
                    Tie = table.Column<int>(type: "int", nullable: false),
                    AverageWin = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockPaperScissorsMatchData", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "RockPaperScissorsRoundData",
                columns: table => new
                {
                    RoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Win = table.Column<int>(type: "int", nullable: false),
                    Loss = table.Column<int>(type: "int", nullable: false),
                    Tie = table.Column<int>(type: "int", nullable: false),
                    Player = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Move = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockPaperScissorsRoundData", x => x.RoundId);
                });

            migrationBuilder.CreateTable(
                name: "ShapeData",
                columns: table => new
                {
                    ShapesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Diagonal1 = table.Column<double>(type: "float", nullable: false),
                    Diagonal2 = table.Column<double>(type: "float", nullable: false),
                    SideA = table.Column<double>(type: "float", nullable: false),
                    SideB = table.Column<double>(type: "float", nullable: false),
                    SideC = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeData", x => x.ShapesId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatorData");

            migrationBuilder.DropTable(
                name: "RockPaperScissorsMatchData");

            migrationBuilder.DropTable(
                name: "RockPaperScissorsRoundData");

            migrationBuilder.DropTable(
                name: "ShapeData");
        }
    }
}
