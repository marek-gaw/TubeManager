using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TubeManager.Infrastructure.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ImportInfoBookmarkId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImportId",
                table: "ImportInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportId",
                table: "ImportInfos");
        }
    }
}
