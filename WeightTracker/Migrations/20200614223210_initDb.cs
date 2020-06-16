using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeightTracker.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    UserInfoGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LoginInfo_UserInfo_UserInfoGuid",
                        column: x => x.UserInfoGuid,
                        principalTable: "UserInfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementRecords",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserInfoGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementRecords", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MeasurementRecords_UserInfo_UserInfoGuid",
                        column: x => x.UserInfoGuid,
                        principalTable: "UserInfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingRecords",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserInfoGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRecords", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TrainingRecords_UserInfo_UserInfoGuid",
                        column: x => x.UserInfoGuid,
                        principalTable: "UserInfo",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BodyParameters",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Chest = table.Column<float>(nullable: false),
                    Biceps = table.Column<float>(nullable: false),
                    Waist = table.Column<float>(nullable: false),
                    Hips = table.Column<float>(nullable: false),
                    Thigh = table.Column<float>(nullable: false),
                    Calf = table.Column<float>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    MeasurementRecordGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyParameters", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_BodyParameters_MeasurementRecords_MeasurementRecordGuid",
                        column: x => x.MeasurementRecordGuid,
                        principalTable: "MeasurementRecords",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingNotes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TrainingRecordGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingNotes", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TrainingNotes_TrainingRecords_TrainingRecordGuid",
                        column: x => x.TrainingRecordGuid,
                        principalTable: "TrainingRecords",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyParameters_MeasurementRecordGuid",
                table: "BodyParameters",
                column: "MeasurementRecordGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginInfo_UserInfoGuid",
                table: "LoginInfo",
                column: "UserInfoGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementRecords_UserInfoGuid",
                table: "MeasurementRecords",
                column: "UserInfoGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingNotes_TrainingRecordGuid",
                table: "TrainingNotes",
                column: "TrainingRecordGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRecords_UserInfoGuid",
                table: "TrainingRecords",
                column: "UserInfoGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyParameters");

            migrationBuilder.DropTable(
                name: "LoginInfo");

            migrationBuilder.DropTable(
                name: "TrainingNotes");

            migrationBuilder.DropTable(
                name: "MeasurementRecords");

            migrationBuilder.DropTable(
                name: "TrainingRecords");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
