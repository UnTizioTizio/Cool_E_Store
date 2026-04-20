using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolEStore.Migrations
{
    /// <inheritdoc />
    public partial class FixedPropertiesModifiersAndAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "Product",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Product",
                type: "DECIMAL(18, 2)",
                nullable: false,
                computedColumnSql: "[BasePrice] * (1 - IFNULL([Sales], 0) / 100.0)",
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldComputedColumnSql: "[BasePrice] * (1 - IFNULL([Sales], 0) / 100.0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "Product",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Product",
                type: "TEXT",
                nullable: false,
                computedColumnSql: "[BasePrice] * (1 - IFNULL([Sales], 0) / 100.0)",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldComputedColumnSql: "[BasePrice] * (1 - IFNULL([Sales], 0) / 100.0)");
        }
    }
}
