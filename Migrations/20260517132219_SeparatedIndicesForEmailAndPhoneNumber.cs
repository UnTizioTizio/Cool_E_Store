using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolEStore.Migrations
{
    /// <inheritdoc />
    public partial class SeparatedIndicesForEmailAndPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email_PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email_PhoneNumber",
                table: "AspNetUsers",
                columns: new[] { "Email", "PhoneNumber" },
                unique: true);
        }
    }
}
