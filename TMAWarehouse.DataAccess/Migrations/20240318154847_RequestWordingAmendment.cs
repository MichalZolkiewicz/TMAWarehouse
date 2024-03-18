using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMAWarehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RequestWordingAmendment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequest_Items_ItemId",
                table: "ItemRequest");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemRequest",
                newName: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequest_Items_ItemsId",
                table: "ItemRequest",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequest_Items_ItemsId",
                table: "ItemRequest");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "ItemRequest",
                newName: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequest_Items_ItemId",
                table: "ItemRequest",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
