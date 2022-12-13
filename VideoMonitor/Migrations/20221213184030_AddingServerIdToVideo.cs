using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoMonitor.Migrations
{
    /// <inheritdoc />
    public partial class AddingServerIdToVideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ServerId",
                table: "Videos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ServerId",
                table: "Videos",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Servers_ServerId",
                table: "Videos",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Servers_ServerId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ServerId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Videos");
        }
    }
}
