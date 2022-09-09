using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WrathLC.DataEngine.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemInventorySlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInventorySlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemQualities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemQualities", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "ItemSockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LichKingEquipmentMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Armor = table.Column<int>(type: "INTEGER", nullable: true),
                    Durability = table.Column<int>(type: "INTEGER", nullable: true),
                    Agility = table.Column<int>(type: "INTEGER", nullable: true),
                    Strength = table.Column<int>(type: "INTEGER", nullable: true),
                    Intellect = table.Column<int>(type: "INTEGER", nullable: true),
                    Spirit = table.Column<int>(type: "INTEGER", nullable: true),
                    Stamina = table.Column<int>(type: "INTEGER", nullable: true),
                    LevelRequirement = table.Column<int>(type: "INTEGER", nullable: true),
                    VendorPrice = table.Column<int>(type: "INTEGER", nullable: true),
                    SocketCount = table.Column<int>(type: "INTEGER", nullable: true),
                    Socket1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Socket2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Socket3Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Socket4Id = table.Column<int>(type: "INTEGER", nullable: true),
                    SocketBonusId = table.Column<int>(type: "INTEGER", nullable: true),
                    HitRating = table.Column<int>(type: "INTEGER", nullable: true),
                    HasteRating = table.Column<int>(type: "INTEGER", nullable: true),
                    ManaRegen = table.Column<int>(type: "INTEGER", nullable: true),
                    SpellDamage = table.Column<int>(type: "INTEGER", nullable: true),
                    Healing = table.Column<int>(type: "INTEGER", nullable: true),
                    DefenseRating = table.Column<int>(type: "INTEGER", nullable: true),
                    ParryRating = table.Column<int>(type: "INTEGER", nullable: true),
                    DodgeRating = table.Column<int>(type: "INTEGER", nullable: true),
                    CriticalStrikeRating = table.Column<int>(type: "INTEGER", nullable: true),
                    MeleeAttackPower = table.Column<int>(type: "INTEGER", nullable: true),
                    ExpertiseRating = table.Column<int>(type: "INTEGER", nullable: true),
                    RangedAttackPower = table.Column<int>(type: "INTEGER", nullable: true),
                    WeaponDamageMinimum = table.Column<int>(type: "INTEGER", nullable: true),
                    WeaponDamageMaximum = table.Column<int>(type: "INTEGER", nullable: true),
                    WeaponDps = table.Column<double>(type: "REAL", nullable: true),
                    WeaponSpeed = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichKingEquipmentMetadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WowClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    WowheadFlagEnumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WowheadIcon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WowheadIcon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ItemClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSubClasses_ItemClasses_ItemClassId",
                        column: x => x.ItemClassId,
                        principalTable: "ItemClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ItemLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemSubClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemQualityId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemInventorySlotId = table.Column<int>(type: "INTEGER", nullable: false),
                    WowheadIconId = table.Column<int>(type: "INTEGER", nullable: false),
                    LichKingEquipmentMetadataId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemInventorySlots_ItemInventorySlotId",
                        column: x => x.ItemInventorySlotId,
                        principalTable: "ItemInventorySlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemQualities_ItemQualityId",
                        column: x => x.ItemQualityId,
                        principalTable: "ItemQualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemSubClasses_ItemSubClassId",
                        column: x => x.ItemSubClassId,
                        principalTable: "ItemSubClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_WowheadIcon_WowheadIconId",
                        column: x => x.WowheadIconId,
                        principalTable: "WowheadIcon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemClassRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WowClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClassRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemClassRestrictions_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemClassRestrictions_WowClasses_WowClassId",
                        column: x => x.WowClassId,
                        principalTable: "WowClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 1, "Warrior", 1 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 2, "Paladin", 2 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 3, "Hunter", 4 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 4, "Rogue", 8 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 5, "Priest", 16 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 6, "Death Knight", 32 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 7, "Shaman", 64 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 8, "Mage", 128 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 9, "Warlock", 256 });

            migrationBuilder.InsertData(
                table: "WowClasses",
                columns: new[] { "Id", "Name", "WowheadFlagEnumId" },
                values: new object[] { 10, "Druid", 1024 });

            migrationBuilder.CreateIndex(
                name: "IX_ItemClassRestrictions_ItemId",
                table: "ItemClassRestrictions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemClassRestrictions_WowClassId",
                table: "ItemClassRestrictions",
                column: "WowClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemInventorySlotId",
                table: "Items",
                column: "ItemInventorySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemQualityId",
                table: "Items",
                column: "ItemQualityId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemSubClassId",
                table: "Items",
                column: "ItemSubClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WowheadIconId",
                table: "Items",
                column: "WowheadIconId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubClasses_ItemClassId",
                table: "ItemSubClasses",
                column: "ItemClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemClassRestrictions");

            migrationBuilder.DropTable(
                name: "ItemSocketBonuses");

            migrationBuilder.DropTable(
                name: "ItemSockets");

            migrationBuilder.DropTable(
                name: "LichKingEquipmentMetadata");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "WowClasses");

            migrationBuilder.DropTable(
                name: "ItemInventorySlots");

            migrationBuilder.DropTable(
                name: "ItemQualities");

            migrationBuilder.DropTable(
                name: "ItemSubClasses");

            migrationBuilder.DropTable(
                name: "WowheadIcon");

            migrationBuilder.DropTable(
                name: "ItemClasses");
        }
    }
}
