using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WrathLc.Core.ResourceAccess.Migrations
{
    public partial class Add_Items_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "items");

            migrationBuilder.CreateTable(
                name: "Icons",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemClasses",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemInventorySlots",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInventorySlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemQualities",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemQualities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSockets",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "schema",
                schema: "items",
                columns: table => new
                {
                    Version = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SeedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schema", x => x.Version);
                });

            migrationBuilder.CreateTable(
                name: "WowClasses",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    WowheadFlagEnumId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubClasses",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ItemClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSubClasses_ItemClasses_ItemClassId",
                        column: x => x.ItemClassId,
                        principalSchema: "items",
                        principalTable: "ItemClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LichKingEquipmentMetadata",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Armor = table.Column<int>(type: "integer", nullable: true),
                    Durability = table.Column<int>(type: "integer", nullable: true),
                    Agility = table.Column<int>(type: "integer", nullable: true),
                    Strength = table.Column<int>(type: "integer", nullable: true),
                    Intellect = table.Column<int>(type: "integer", nullable: true),
                    Spirit = table.Column<int>(type: "integer", nullable: true),
                    Stamina = table.Column<int>(type: "integer", nullable: true),
                    LevelRequirement = table.Column<int>(type: "integer", nullable: true),
                    VendorPrice = table.Column<int>(type: "integer", nullable: true),
                    SocketCount = table.Column<int>(type: "integer", nullable: true),
                    Socket1Id = table.Column<int>(type: "integer", nullable: true),
                    Socket2Id = table.Column<int>(type: "integer", nullable: true),
                    Socket3Id = table.Column<int>(type: "integer", nullable: true),
                    SocketBonusId = table.Column<int>(type: "integer", nullable: true),
                    HitRating = table.Column<int>(type: "integer", nullable: true),
                    HasteRating = table.Column<int>(type: "integer", nullable: true),
                    ManaRegen = table.Column<int>(type: "integer", nullable: true),
                    SpellDamage = table.Column<int>(type: "integer", nullable: true),
                    Healing = table.Column<int>(type: "integer", nullable: true),
                    DefenseRating = table.Column<int>(type: "integer", nullable: true),
                    ParryRating = table.Column<int>(type: "integer", nullable: true),
                    DodgeRating = table.Column<int>(type: "integer", nullable: true),
                    CriticalStrikeRating = table.Column<int>(type: "integer", nullable: true),
                    MeleeAttackPower = table.Column<int>(type: "integer", nullable: true),
                    ExpertiseRating = table.Column<int>(type: "integer", nullable: true),
                    RangedAttackPower = table.Column<int>(type: "integer", nullable: true),
                    WeaponDamageMinimum = table.Column<int>(type: "integer", nullable: true),
                    WeaponDamageMaximum = table.Column<int>(type: "integer", nullable: true),
                    WeaponDps = table.Column<double>(type: "double precision", nullable: true),
                    WeaponSpeed = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichKingEquipmentMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket1Id",
                        column: x => x.Socket1Id,
                        principalSchema: "items",
                        principalTable: "ItemSockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket2Id",
                        column: x => x.Socket2Id,
                        principalSchema: "items",
                        principalTable: "ItemSockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LichKingEquipmentMetadata_ItemSockets_Socket3Id",
                        column: x => x.Socket3Id,
                        principalSchema: "items",
                        principalTable: "ItemSockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ItemLevel = table.Column<int>(type: "integer", nullable: false),
                    ItemSubClassId = table.Column<int>(type: "integer", nullable: false),
                    ItemQualityId = table.Column<int>(type: "integer", nullable: false),
                    ItemInventorySlotId = table.Column<int>(type: "integer", nullable: false),
                    IconId = table.Column<int>(type: "integer", nullable: false),
                    LichKingEquipmentMetadataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Icons_IconId",
                        column: x => x.IconId,
                        principalSchema: "items",
                        principalTable: "Icons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ItemInventorySlots_ItemInventorySlotId",
                        column: x => x.ItemInventorySlotId,
                        principalSchema: "items",
                        principalTable: "ItemInventorySlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ItemQualities_ItemQualityId",
                        column: x => x.ItemQualityId,
                        principalSchema: "items",
                        principalTable: "ItemQualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ItemSubClasses_ItemSubClassId",
                        column: x => x.ItemSubClassId,
                        principalSchema: "items",
                        principalTable: "ItemSubClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_LichKingEquipmentMetadata_LichKingEquipmentMetadataId",
                        column: x => x.LichKingEquipmentMetadataId,
                        principalSchema: "items",
                        principalTable: "LichKingEquipmentMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemClassRestrictions",
                schema: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WowClassId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClassRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemClassRestrictions_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "items",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemClassRestrictions_WowClasses_WowClassId",
                        column: x => x.WowClassId,
                        principalSchema: "items",
                        principalTable: "WowClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "items",
                table: "ItemSockets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meta" },
                    { 2, "Red" },
                    { 3, "Yellow" },
                    { 4, "Blue" }
                });

            migrationBuilder.InsertData(
                schema: "items",
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[,]
                {
                    { 1, "Warrior", 1 },
                    { 2, "Paladin", 2 },
                    { 3, "Hunter", 4 },
                    { 4, "Rogue", 8 },
                    { 5, "Priest", 16 },
                    { 6, "Death Knight", 32 },
                    { 7, "Shaman", 64 },
                    { 8, "Mage", 128 },
                    { 9, "Warlock", 256 },
                    { 10, "Druid", 1024 }
                });

            migrationBuilder.InsertData(
                schema: "items",
                table: "schema",
                columns: new[] { "Version", "SeedDate", "SeedName" },
                values: new object[] { 1, null, "Initial v1.0" });

            migrationBuilder.CreateIndex(
                name: "IX_Icons_Name",
                schema: "items",
                table: "Icons",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ItemClasses_Name",
                schema: "items",
                table: "ItemClasses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ItemClassRestrictions_ItemId",
                schema: "items",
                table: "ItemClassRestrictions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemClassRestrictions_WowClassId",
                schema: "items",
                table: "ItemClassRestrictions",
                column: "WowClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInventorySlots_Name",
                schema: "items",
                table: "ItemInventorySlots",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ItemQualities_Name",
                schema: "items",
                table: "ItemQualities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Items_IconId",
                schema: "items",
                table: "Items",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemInventorySlotId",
                schema: "items",
                table: "Items",
                column: "ItemInventorySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemQualityId",
                schema: "items",
                table: "Items",
                column: "ItemQualityId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemSubClassId",
                schema: "items",
                table: "Items",
                column: "ItemSubClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LichKingEquipmentMetadataId",
                schema: "items",
                table: "Items",
                column: "LichKingEquipmentMetadataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Name",
                schema: "items",
                table: "Items",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSockets_Name",
                schema: "items",
                table: "ItemSockets",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubClasses_ItemClassId",
                schema: "items",
                table: "ItemSubClasses",
                column: "ItemClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubClasses_Name",
                schema: "items",
                table: "ItemSubClasses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_LichKingEquipmentMetadata_Socket1Id",
                schema: "items",
                table: "LichKingEquipmentMetadata",
                column: "Socket1Id");

            migrationBuilder.CreateIndex(
                name: "IX_LichKingEquipmentMetadata_Socket2Id",
                schema: "items",
                table: "LichKingEquipmentMetadata",
                column: "Socket2Id");

            migrationBuilder.CreateIndex(
                name: "IX_LichKingEquipmentMetadata_Socket3Id",
                schema: "items",
                table: "LichKingEquipmentMetadata",
                column: "Socket3Id");

            migrationBuilder.CreateIndex(
                name: "IX_WowClasses_Name",
                schema: "items",
                table: "WowClasses",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemClassRestrictions",
                schema: "items");

            migrationBuilder.DropTable(
                name: "schema",
                schema: "items");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "items");

            migrationBuilder.DropTable(
                name: "WowClasses",
                schema: "items");

            migrationBuilder.DropTable(
                name: "Icons",
                schema: "items");

            migrationBuilder.DropTable(
                name: "ItemInventorySlots",
                schema: "items");

            migrationBuilder.DropTable(
                name: "ItemQualities",
                schema: "items");

            migrationBuilder.DropTable(
                name: "ItemSubClasses",
                schema: "items");

            migrationBuilder.DropTable(
                name: "LichKingEquipmentMetadata",
                schema: "items");

            migrationBuilder.DropTable(
                name: "ItemClasses",
                schema: "items");

            migrationBuilder.DropTable(
                name: "ItemSockets",
                schema: "items");
        }
    }
}
