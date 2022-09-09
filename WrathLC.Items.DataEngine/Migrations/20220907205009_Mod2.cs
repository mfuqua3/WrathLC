using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WrathLC.DataEngine.Migrations
{
    public partial class Mod2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSocketBonuses");

            migrationBuilder.InsertData(
                table: "ItemSockets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Meta" });

            migrationBuilder.InsertData(
                table: "ItemSockets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Red" });

            migrationBuilder.InsertData(
                table: "ItemSockets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Yellow" });

            migrationBuilder.InsertData(
                table: "ItemSockets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Blue" });

            migrationBuilder.CreateIndex(
                name: "IX_LichKingEquipmentMetadata_Socket1Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket1Id");

            migrationBuilder.CreateIndex(
                name: "IX_LichKingEquipmentMetadata_Socket2Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket2Id");

            migrationBuilder.CreateIndex(
                name: "IX_LichKingEquipmentMetadata_Socket3Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket3Id");

            migrationBuilder.CreateIndex(
                name: "IX_LichKingEquipmentMetadata_Socket4Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket4Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket1Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket1Id",
                principalTable: "ItemSockets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket2Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket2Id",
                principalTable: "ItemSockets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket3Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket3Id",
                principalTable: "ItemSockets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket4Id",
                table: "LichKingEquipmentMetadata",
                column: "Socket4Id",
                principalTable: "ItemSockets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket1Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DropForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket2Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DropForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket3Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DropForeignKey(
                name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket4Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DropIndex(
                name: "IX_LichKingEquipmentMetadata_Socket1Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DropIndex(
                name: "IX_LichKingEquipmentMetadata_Socket2Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DropIndex(
                name: "IX_LichKingEquipmentMetadata_Socket3Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DropIndex(
                name: "IX_LichKingEquipmentMetadata_Socket4Id",
                table: "LichKingEquipmentMetadata");

            migrationBuilder.DeleteData(
                table: "ItemSockets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemSockets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemSockets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemSockets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "ItemSocketBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSocketBonuses", x => x.Id);
                });
        }
    }
}
