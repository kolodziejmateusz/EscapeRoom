using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscapeRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EscapeRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressDetails_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDetails_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDetails_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDetails_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscapeRooms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscapeRooms");
        }
    }
}
