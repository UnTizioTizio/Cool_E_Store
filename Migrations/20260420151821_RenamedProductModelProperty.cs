using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolEStore.Migrations
{
    /// <inheritdoc />
    public partial class RenamedProductModelProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sales",
                table: "Product",
                newName: "Discount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Product",
                newName: "Sales");
        }
    }
}
