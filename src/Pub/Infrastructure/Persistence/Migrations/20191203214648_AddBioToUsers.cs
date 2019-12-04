using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddBioToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(3810), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6830), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6830), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8050), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8050), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8450), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9200), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(50), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(50), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3530), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3530), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3900), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3900), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6210), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6210), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6580), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6580), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7770), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7770), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8130), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8860), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8870), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9630), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(470), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(470), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 272, DateTimeKind.Unspecified).AddTicks(2100), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 272, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CommunicationPlatforms",
                keyColumn: "Id",
                keyValue: new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 272, DateTimeKind.Unspecified).AddTicks(4850), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 272, DateTimeKind.Unspecified).AddTicks(4850), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 268, DateTimeKind.Unspecified).AddTicks(9200), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(4460), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(4550), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(5740), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(8200), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(8210), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(9370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(9370), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(9730), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 269, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(520), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(880), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(2510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(2510), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(3650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(3650), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(4070), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(4070), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(6900), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(6900), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(7470), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(7470), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(7900), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(7900), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(8710), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(8710), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(9850), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 270, DateTimeKind.Unspecified).AddTicks(9850), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(220), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(580), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(580), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(1710), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 12, 1, 5, 55, 47, 271, DateTimeKind.Unspecified).AddTicks(1710), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
