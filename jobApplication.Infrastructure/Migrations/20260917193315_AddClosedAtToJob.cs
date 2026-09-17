using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClosedAtToJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "jobs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "jobs");
        }
    }
}
