using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamexCloneApp.Migrations
{
    public partial class UpdateHomeSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageUrl",
                table: "HomeSliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImageUrl",
                table: "HomeSliders");
        }
    }
}
