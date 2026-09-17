using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJobCandidateApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCandidateApplication_candidates_CandidateId",
                table: "JobCandidateApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCandidateApplication_jobs_JobId",
                table: "JobCandidateApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCandidateApplication",
                table: "JobCandidateApplication");

            migrationBuilder.RenameTable(
                name: "JobCandidateApplication",
                newName: "JobCandidateApplications");

            migrationBuilder.RenameIndex(
                name: "IX_JobCandidateApplication_JobId",
                table: "JobCandidateApplications",
                newName: "IX_JobCandidateApplications_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCandidateApplication_CandidateId",
                table: "JobCandidateApplications",
                newName: "IX_JobCandidateApplications_CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "CvUrl",
                table: "candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCandidateApplications",
                table: "JobCandidateApplications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCandidateApplications_candidates_CandidateId",
                table: "JobCandidateApplications",
                column: "CandidateId",
                principalTable: "candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCandidateApplications_jobs_JobId",
                table: "JobCandidateApplications",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCandidateApplications_candidates_CandidateId",
                table: "JobCandidateApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCandidateApplications_jobs_JobId",
                table: "JobCandidateApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCandidateApplications",
                table: "JobCandidateApplications");

            migrationBuilder.RenameTable(
                name: "JobCandidateApplications",
                newName: "JobCandidateApplication");

            migrationBuilder.RenameIndex(
                name: "IX_JobCandidateApplications_JobId",
                table: "JobCandidateApplication",
                newName: "IX_JobCandidateApplication_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCandidateApplications_CandidateId",
                table: "JobCandidateApplication",
                newName: "IX_JobCandidateApplication_CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "CvUrl",
                table: "candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCandidateApplication",
                table: "JobCandidateApplication",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCandidateApplication_candidates_CandidateId",
                table: "JobCandidateApplication",
                column: "CandidateId",
                principalTable: "candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCandidateApplication_jobs_JobId",
                table: "JobCandidateApplication",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
