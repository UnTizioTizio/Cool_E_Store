using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolEStore.Migrations
{
    /// <inheritdoc />
    public partial class FixedFinalPriceComputedColumnForTheSecondTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Product",
                type: "DECIMAL(18, 2)",
                nullable: false,
                computedColumnSql: "ROUND([BasePrice] * (1 - IFNULL([Discount], 0) / 100.0), 2)",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldComputedColumnSql: "CAST([BasePrice] * (1 - IFNULL([Discount], 0) / 100.0) AS DECIMAL(18,2))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Product",
                type: "DECIMAL(18, 2)",
                nullable: false,
                computedColumnSql: "CAST([BasePrice] * (1 - IFNULL([Discount], 0) / 100.0) AS DECIMAL(18,2))",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldComputedColumnSql: "ROUND([BasePrice] * (1 - IFNULL([Discount], 0) / 100.0), 2)");
        }
    }
}
