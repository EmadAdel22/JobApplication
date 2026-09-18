using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "candidates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidates_UserId",
                table: "candidates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_candidates_users_UserId",
                table: "candidates",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidates_users_UserId",
                table: "candidates");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_candidates_UserId",
                table: "candidates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "candidates");
        }
    }
}
