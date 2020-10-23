using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddDeactivatedFlagToChatAppTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deactived",
                table: "ChatAppUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deactived",
                table: "ChatAppUsers");
        }
    }
}
