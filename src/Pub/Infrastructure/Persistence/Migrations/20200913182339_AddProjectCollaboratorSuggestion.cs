using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddProjectCollaboratorSuggestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCollaboratorSuggestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCollaboratorSuggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCollaboratorSuggestions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectCollaboratorSuggestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 21, DateTimeKind.Unspecified).AddTicks(8370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 21, DateTimeKind.Unspecified).AddTicks(8800), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 22, DateTimeKind.Unspecified).AddTicks(610), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 22, DateTimeKind.Unspecified).AddTicks(620), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(5220), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(5700), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(7600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(7610), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(8120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(8120), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(8510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(9360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(9360), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(9760), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 18, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(480), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(480), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(880), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(880), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(1240), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(1240), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(3610), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(4780), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(4780), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(6320), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(6320), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(7020), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(7020), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(7410), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(7760), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(8190), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(8190), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(8560), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(8560), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(9300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(9300), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 19, DateTimeKind.Unspecified).AddTicks(9660), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(10), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(20), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(440), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(440), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(810), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(810), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(1970), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 13, 18, 23, 39, 20, DateTimeKind.Unspecified).AddTicks(1970), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCollaboratorSuggestions_ProjectId",
                table: "ProjectCollaboratorSuggestions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCollaboratorSuggestions_UserId",
                table: "ProjectCollaboratorSuggestions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCollaboratorSuggestions");

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(6440), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(8650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 886, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 886, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4960), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4970), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5870), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6710), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6710), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7730), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8160), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8970), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8970), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3390), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3400), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4140), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4890), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4900), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8210), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8210), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8560), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8570), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
