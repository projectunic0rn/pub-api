using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddLogoUrlToCommunicationPlatformType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "CommunicationPlatforms",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(6970), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 946, DateTimeKind.Unspecified).AddTicks(8180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 946, DateTimeKind.Unspecified).AddTicks(8640), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(490), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(500), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(1050), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(1060), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(1820), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(1820), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(3890), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(3900), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(5040), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(5860), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(5860), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(6620), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(6620), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(7860), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(7860), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(8230), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(8230), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(8630), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(9340), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(9340), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(9750), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 947, DateTimeKind.Unspecified).AddTicks(9760), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(1290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(1290), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(2000), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(2000), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(2870), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(2870), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(3600), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(4000), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(4000), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(4720), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(4720), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 948, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "CommunicationPlatforms");

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 921, DateTimeKind.Unspecified).AddTicks(821), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 921, DateTimeKind.Unspecified).AddTicks(1495), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 921, DateTimeKind.Unspecified).AddTicks(3448), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 921, DateTimeKind.Unspecified).AddTicks(3455), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 916, DateTimeKind.Unspecified).AddTicks(6329), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 917, DateTimeKind.Unspecified).AddTicks(5840), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 917, DateTimeKind.Unspecified).AddTicks(8929), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 917, DateTimeKind.Unspecified).AddTicks(8935), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 917, DateTimeKind.Unspecified).AddTicks(9423), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 917, DateTimeKind.Unspecified).AddTicks(9425), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 917, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 917, DateTimeKind.Unspecified).AddTicks(9832), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(214), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(602), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(1428), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(1429), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(1859), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(2234), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(2607), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(2608), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(3705), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(3706), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(4083), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(4084), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(4501), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(4940), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(4942), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(5334), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(5335), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(5707), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(5708), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(6074), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(6075), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(6442), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(6443), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(6858), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(6860), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(7220), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(7222), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(7733), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(7734), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(8114), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(8115), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(8480), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(8481), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(8845), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(9203), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(9618), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(9979), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 918, DateTimeKind.Unspecified).AddTicks(9980), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(388), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(749), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(1472), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(1474), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(1835), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(1836), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(3065), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(3625), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(3999), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 29, 18, 55, 18, 919, DateTimeKind.Unspecified).AddTicks(4000), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
