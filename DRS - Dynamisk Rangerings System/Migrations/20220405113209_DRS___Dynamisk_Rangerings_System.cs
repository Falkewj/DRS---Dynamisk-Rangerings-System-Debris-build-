﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DRS___Dynamisk_Rangerings_System.Migrations
{
    public partial class DRS___Dynamisk_Rangerings_System : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WonMatches = table.Column<int>(type: "int", nullable: false),
                    SecondMatches = table.Column<int>(type: "int", nullable: false),
                    LostMatches = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}
