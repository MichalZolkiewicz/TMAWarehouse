using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMAWarehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RequestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Items_ItemId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ItemId",
                table: "Requests");

            migrationBuilder.CreateTable(
                name: "ItemRequest",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    RequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequest", x => new { x.ItemId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_ItemRequest_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequest_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequest_RequestsId",
                table: "ItemRequest",
                column: "RequestsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRequest");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ItemId",
                table: "Requests",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Items_ItemId",
                table: "Requests",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
