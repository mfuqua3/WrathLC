using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WrathLC.DataEngine.Migrations
{
    public partial class Mod1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_WowheadIcon_WowheadIconId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WowheadIcon",
                table: "WowheadIcon");

            migrationBuilder.RenameTable(
                name: "WowheadIcon",
                newName: "WowheadIcons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WowheadIcons",
                table: "WowheadIcons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LichKingEquipmentMetadataId",
                table: "Items",
                column: "LichKingEquipmentMetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_LichKingEquipmentMetadata_LichKingEquipmentMetadataId",
                table: "Items",
                column: "LichKingEquipmentMetadataId",
                principalTable: "LichKingEquipmentMetadata",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_WowheadIcons_WowheadIconId",
                table: "Items",
                column: "WowheadIconId",
                principalTable: "WowheadIcons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_LichKingEquipmentMetadata_LichKingEquipmentMetadataId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_WowheadIcons_WowheadIconId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_LichKingEquipmentMetadataId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WowheadIcons",
                table: "WowheadIcons");

            migrationBuilder.RenameTable(
                name: "WowheadIcons",
                newName: "WowheadIcon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WowheadIcon",
                table: "WowheadIcon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_WowheadIcon_WowheadIconId",
                table: "Items",
                column: "WowheadIconId",
                principalTable: "WowheadIcon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
