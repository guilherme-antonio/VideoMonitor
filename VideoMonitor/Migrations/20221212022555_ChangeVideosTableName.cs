using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoMonitor.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVideosTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_videos",
                table: "videos");

            migrationBuilder.RenameTable(
                name: "videos",
                newName: "Videos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "videos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_videos",
                table: "videos",
                column: "Id");
        }
    }
}
