using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestLiveCode.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Example",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExampleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DETAILS = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    Example_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleDetails_Example_Example_Id",
                        column: x => x.Example_Id,
                        principalTable: "Example",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExampleDetails_Example_Id",
                table: "ExampleDetails",
                column: "Example_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleDetails");

            migrationBuilder.DropTable(
                name: "Example");
        }
    }
}
