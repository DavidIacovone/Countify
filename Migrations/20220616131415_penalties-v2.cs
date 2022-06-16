using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countify.Migrations
{
    public partial class penaltiesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Penalties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Penalties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Penalties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Penalties");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Penalties");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Penalties");
        }
    }
}
