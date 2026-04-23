using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolEStore.Migrations
{
    /// <inheritdoc />
    public partial class FirstDatabaseSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CAP",
                table: "Vendor",
                type: "TEXT",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CAP",
                table: "User",
                type: "TEXT",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<byte>(
                name: "Discount",
                table: "Product",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Product",
                type: "DECIMAL(18, 2)",
                nullable: false,
                computedColumnSql: "[BasePrice] * (1 - IFNULL([Discount], 0) / 100.0)",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldComputedColumnSql: "[BasePrice] * (1 - IFNULL([Sales], 0) / 100.0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "CAP",
                table: "Vendor",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<uint>(
                name: "CAP",
                table: "User",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<byte>(
                name: "Discount",
                table: "Product",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Product",
                type: "DECIMAL(18, 2)",
                nullable: false,
                computedColumnSql: "[BasePrice] * (1 - IFNULL([Sales], 0) / 100.0)",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldComputedColumnSql: "[BasePrice] * (1 - IFNULL([Discount], 0) / 100.0)");
        }
    }
}
