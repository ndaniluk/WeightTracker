using Microsoft.EntityFrameworkCore.Migrations;

namespace WeightTracker.Migrations
{
    public partial class Deletecascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementRecords_AspNetUsers_UserId",
                table: "MeasurementRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingRecords_AspNetUsers_UserId",
                table: "TrainingRecords");

            migrationBuilder.CreateTable(
                name: "AdminPanelUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPanelUser", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementRecords_AspNetUsers_UserId",
                table: "MeasurementRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingRecords_AspNetUsers_UserId",
                table: "TrainingRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementRecords_AspNetUsers_UserId",
                table: "MeasurementRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingRecords_AspNetUsers_UserId",
                table: "TrainingRecords");

            migrationBuilder.DropTable(
                name: "AdminPanelUser");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementRecords_AspNetUsers_UserId",
                table: "MeasurementRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingRecords_AspNetUsers_UserId",
                table: "TrainingRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
