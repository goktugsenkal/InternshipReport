using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntryOnDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportEntry_InternshipReports_InternshipReportId",
                table: "ReportEntry");

            migrationBuilder.AlterColumn<int>(
                name: "InternshipReportId",
                table: "ReportEntry",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportEntry_InternshipReports_InternshipReportId",
                table: "ReportEntry",
                column: "InternshipReportId",
                principalTable: "InternshipReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportEntry_InternshipReports_InternshipReportId",
                table: "ReportEntry");

            migrationBuilder.AlterColumn<int>(
                name: "InternshipReportId",
                table: "ReportEntry",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportEntry_InternshipReports_InternshipReportId",
                table: "ReportEntry",
                column: "InternshipReportId",
                principalTable: "InternshipReports",
                principalColumn: "Id");
        }
    }
}
