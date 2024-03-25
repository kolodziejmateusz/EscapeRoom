using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscapeRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CreatedById",
                table: "Reviews",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CreatedById",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Reviews");
        }
    }
}
