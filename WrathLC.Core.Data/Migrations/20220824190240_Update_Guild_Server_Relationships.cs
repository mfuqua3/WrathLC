using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WrathLc.Core.ResourceAccess.Migrations
{
    public partial class Update_Guild_Server_Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Guilds_DiscordServerId",
                table: "Guilds");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "GuildUsers",
                newName: "IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_GuildUsers_Deleted",
                table: "GuildUsers",
                newName: "IX_GuildUsers_IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Guilds",
                newName: "IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Guilds_Deleted",
                table: "Guilds",
                newName: "IX_Guilds_IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "DiscordServerUsers",
                newName: "IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_DiscordServerUsers_Deleted",
                table: "DiscordServerUsers",
                newName: "IX_DiscordServerUsers_IsDeleted");

            migrationBuilder.AddColumn<int>(
                name: "GuildId",
                table: "GuildUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GuildUsers_GuildId",
                table: "GuildUsers",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Guilds_DiscordServerId",
                table: "Guilds",
                column: "DiscordServerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GuildUsers_Guilds_GuildId",
                table: "GuildUsers",
                column: "GuildId",
                principalTable: "Guilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuildUsers_Guilds_GuildId",
                table: "GuildUsers");

            migrationBuilder.DropIndex(
                name: "IX_GuildUsers_GuildId",
                table: "GuildUsers");

            migrationBuilder.DropIndex(
                name: "IX_Guilds_DiscordServerId",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "GuildId",
                table: "GuildUsers");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "GuildUsers",
                newName: "Deleted");

            migrationBuilder.RenameIndex(
                name: "IX_GuildUsers_IsDeleted",
                table: "GuildUsers",
                newName: "IX_GuildUsers_Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Guilds",
                newName: "Deleted");

            migrationBuilder.RenameIndex(
                name: "IX_Guilds_IsDeleted",
                table: "Guilds",
                newName: "IX_Guilds_Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "DiscordServerUsers",
                newName: "Deleted");

            migrationBuilder.RenameIndex(
                name: "IX_DiscordServerUsers_IsDeleted",
                table: "DiscordServerUsers",
                newName: "IX_DiscordServerUsers_Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Guilds_DiscordServerId",
                table: "Guilds",
                column: "DiscordServerId");
        }
    }
}
