using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddExtendedMarkdownDescriptionToProjectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtendedMarkdownDescription",
                table: "Projects",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "LogoUrl", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(6440), new TimeSpan(0, 0, 0, 0, 0)), "https://i.imgur.com/y3e8lL6.png", new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "LogoUrl", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(8650), new TimeSpan(0, 0, 0, 0, 0)), "https://i.imgur.com/BoARUGM.png", new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 0, 0, 0, 0)) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtendedMarkdownDescription",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "LogoUrl", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(6970), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "LogoUrl", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(8930), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2020, 8, 20, 23, 18, 36, 950, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 0, 0, 0, 0)) });

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
    }
}
