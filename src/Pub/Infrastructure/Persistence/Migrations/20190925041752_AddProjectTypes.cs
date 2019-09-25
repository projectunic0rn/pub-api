using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddProjectTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "Id", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(6930), new TimeSpan(0, 0, 0, 0, 0)), "Adtech", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(7560), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(6560), new TimeSpan(0, 0, 0, 0, 0)), "Hard Tech", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(6560), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 0, 0, 0, 0)), "Hardware", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(7270), new TimeSpan(0, 0, 0, 0, 0)), "Healthcare", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(7280), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 0, 0, 0, 0)), "Insurance", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(7660), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(8000), new TimeSpan(0, 0, 0, 0, 0)), "Language Learning", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(8000), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(8340), new TimeSpan(0, 0, 0, 0, 0)), "Lending / Loan Management", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(8350), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(8680), new TimeSpan(0, 0, 0, 0, 0)), "Marketplace", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(6210), new TimeSpan(0, 0, 0, 0, 0)), "Government", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 0, 0, 0, 0)), "Media", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(9750), new TimeSpan(0, 0, 0, 0, 0)), "Retail", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(9750), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 0, 0, 0, 0)), "Recruiting/Talent", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(200), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 0, 0, 0, 0)), "Robotics", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 0, 0, 0, 0)), "Security", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(890), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 0, 0, 0, 0)), "Sourcing / Recruiting", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 0, 0, 0, 0)), "Transportation", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(1950), new TimeSpan(0, 0, 0, 0, 0)), "Travel/Tourism", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(1950), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(9410), new TimeSpan(0, 0, 0, 0, 0)), "Public Transportation", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(9420), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(2290), new TimeSpan(0, 0, 0, 0, 0)), "Virtual Reality", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(2290), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(5820), new TimeSpan(0, 0, 0, 0, 0)), "Gaming", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(5820), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 0, 0, 0, 0)), "Food/Beverage", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(5130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(9100), new TimeSpan(0, 0, 0, 0, 0)), "Aerospace", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(9110), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(9550), new TimeSpan(0, 0, 0, 0, 0)), "Agriculture", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(9550), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(9980), new TimeSpan(0, 0, 0, 0, 0)), "Analytics", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 347, DateTimeKind.Unspecified).AddTicks(9980), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 0, 0, 0, 0)), "Augmented Reality", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0)), "Biotech", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 0, 0, 0, 0)), "Community", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(1170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)), "Construction", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 0, 0, 0, 0)), "Freight", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 0, 0, 0, 0)), "Continuing Education", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 0, 0, 0, 0)), "Developer Tools", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(2610), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(2960), new TimeSpan(0, 0, 0, 0, 0)), "E-Sports", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(2960), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 0, 0, 0, 0)), "Education", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(3360), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 0, 0, 0, 0)), "Energy", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(4050), new TimeSpan(0, 0, 0, 0, 0)), "Entertainment", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(4050), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(4390), new TimeSpan(0, 0, 0, 0, 0)), "Financial Services", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(4390), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(4750), new TimeSpan(0, 0, 0, 0, 0)), "Fitness / Wellness", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(4750), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 0, 0, 0, 0)), "Crypto / Blockchain", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 348, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"), new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(2700), new TimeSpan(0, 0, 0, 0, 0)), "Other", new DateTimeOffset(new DateTime(2019, 9, 25, 4, 17, 52, 349, DateTimeKind.Unspecified).AddTicks(2700), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTypes");
        }
    }
}
