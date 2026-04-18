using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolEStore.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysSpecified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBasketRecords_Products_ProductId",
                table: "ShoppingBasketRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBasketRecords_Users_UserId",
                table: "ShoppingBasketRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRecords_Products_ProductId",
                table: "WarehouseRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRecords_Vendors_VendorId",
                table: "WarehouseRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseRecords",
                table: "WarehouseRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingBasketRecords",
                table: "ShoppingBasketRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "WarehouseRecords",
                newName: "WarehouseRecord");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "ShoppingBasketRecords",
                newName: "ShoppingBasketRecord");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseRecords_VendorId",
                table: "WarehouseRecord",
                newName: "IX_WarehouseRecord_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseRecords_ProductId",
                table: "WarehouseRecord",
                newName: "IX_WarehouseRecord_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_Email_PhoneNumber",
                table: "Vendor",
                newName: "IX_Vendor_Email_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email_PhoneNumber",
                table: "User",
                newName: "IX_User_Email_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingBasketRecords_UserId",
                table: "ShoppingBasketRecord",
                newName: "IX_ShoppingBasketRecord_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingBasketRecords_ProductId",
                table: "ShoppingBasketRecord",
                newName: "IX_ShoppingBasketRecord_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductId",
                table: "Review",
                newName: "IX_Review_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseRecord",
                table: "WarehouseRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingBasketRecord",
                table: "ShoppingBasketRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_VendorId",
                table: "Product",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Vendor_VendorId",
                table: "Product",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Product_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBasketRecord_Product_ProductId",
                table: "ShoppingBasketRecord",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBasketRecord_User_UserId",
                table: "ShoppingBasketRecord",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRecord_Product_ProductId",
                table: "WarehouseRecord",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRecord_Vendor_VendorId",
                table: "WarehouseRecord",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Vendor_VendorId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Product_ProductId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBasketRecord_Product_ProductId",
                table: "ShoppingBasketRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBasketRecord_User_UserId",
                table: "ShoppingBasketRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRecord_Product_ProductId",
                table: "WarehouseRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRecord_Vendor_VendorId",
                table: "WarehouseRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseRecord",
                table: "WarehouseRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingBasketRecord",
                table: "ShoppingBasketRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_VendorId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "WarehouseRecord",
                newName: "WarehouseRecords");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "ShoppingBasketRecord",
                newName: "ShoppingBasketRecords");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseRecord_VendorId",
                table: "WarehouseRecords",
                newName: "IX_WarehouseRecords_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseRecord_ProductId",
                table: "WarehouseRecords",
                newName: "IX_WarehouseRecords_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendor_Email_PhoneNumber",
                table: "Vendors",
                newName: "IX_Vendors_Email_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email_PhoneNumber",
                table: "Users",
                newName: "IX_Users_Email_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingBasketRecord_UserId",
                table: "ShoppingBasketRecords",
                newName: "IX_ShoppingBasketRecords_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingBasketRecord_ProductId",
                table: "ShoppingBasketRecords",
                newName: "IX_ShoppingBasketRecords_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ProductId",
                table: "Reviews",
                newName: "IX_Reviews_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseRecords",
                table: "WarehouseRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingBasketRecords",
                table: "ShoppingBasketRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBasketRecords_Products_ProductId",
                table: "ShoppingBasketRecords",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBasketRecords_Users_UserId",
                table: "ShoppingBasketRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRecords_Products_ProductId",
                table: "WarehouseRecords",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRecords_Vendors_VendorId",
                table: "WarehouseRecords",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
