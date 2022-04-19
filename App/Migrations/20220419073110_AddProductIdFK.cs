using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddProductIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookedFoods_Products_ProductId",
                table: "CookedFoods");

            migrationBuilder.DropIndex(
                name: "IX_CookedFoods_ProductId",
                table: "CookedFoods");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CookedFoods");

            migrationBuilder.AddColumn<string>(
                name: "CookedFood_ProductId_FK",
                table: "CookedFoods",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderDTO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDTO", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookedFoods_CookedFood_ProductId_FK",
                table: "CookedFoods",
                column: "CookedFood_ProductId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_CookedFoods_Products_CookedFood_ProductId_FK",
                table: "CookedFoods",
                column: "CookedFood_ProductId_FK",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookedFoods_Products_CookedFood_ProductId_FK",
                table: "CookedFoods");

            migrationBuilder.DropTable(
                name: "OrderDTO");

            migrationBuilder.DropIndex(
                name: "IX_CookedFoods_CookedFood_ProductId_FK",
                table: "CookedFoods");

            migrationBuilder.DropColumn(
                name: "CookedFood_ProductId_FK",
                table: "CookedFoods");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "CookedFoods",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CookedFoods_ProductId",
                table: "CookedFoods",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookedFoods_Products_ProductId",
                table: "CookedFoods",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
