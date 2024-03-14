using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMAWarehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "NetPrice",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasurement",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ItemId",
                table: "Requests",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RequestId",
                table: "Employees",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Requests_RequestId",
                table: "Employees",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Items_ItemId",
                table: "Requests",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Requests_RequestId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Items_ItemId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ItemId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RequestId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "NetPrice",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasurement",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Employees");
        }
    }
}
