﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191203214648_AddBioToUsers")]
    partial class AddBioToUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ChatAppUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.Property<string>("WorkspaceId");

                    b.Property<string>("WorkspaceMemberId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkspaceId", "WorkspaceMemberId")
                        .IsUnique();

                    b.ToTable("ChatAppUsers");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CommunicationPlatformTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("CommunicationPlatforms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(80), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "slack",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "discord",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 312, DateTimeKind.Unspecified).AddTicks(1940), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommunicationPlatform");

                    b.Property<string>("CommunicationPlatformUrl");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTimeOffset>("LaunchDate");

                    b.Property<bool>("LookingForMembers")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Name");

                    b.Property<string>("ProjectType");

                    b.Property<string>("RepositoryUrl");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Type");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(3810), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Adtech",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Aerospace",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6830), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Agriculture",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(6830), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Analytics",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Augmented Reality",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(7670), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8050), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Biotech",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8050), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8450), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Community",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Construction",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9190), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Continuing Education",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9200), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Crypto / Blockchain",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 309, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(50), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Developer Tools",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(50), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "E-Sports",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(410), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Education",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Energy",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Entertainment",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Financial Services",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(1920), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Fitness / Wellness",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Food/Beverage",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Freight",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3170), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3530), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Gaming",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3530), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3900), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Government",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(3900), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Hard Tech",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4270), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Hardware",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Healthcare",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5120), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Insurance",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Language Learning",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6210), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Lending / Loan Management",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6210), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6580), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Marketplace",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6580), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Media",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Public Transportation",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7300), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7770), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Retail",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(7770), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8130), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Recruiting/Talent",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Robotics",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8500), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8860), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Security",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(8870), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Sourcing / Recruiting",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9620), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Transportation",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 310, DateTimeKind.Unspecified).AddTicks(9630), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Travel/Tourism",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(470), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Virtual Reality",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(470), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                            CreatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Other",
                            UpdatedAt = new DateTimeOffset(new DateTime(2019, 12, 3, 21, 46, 48, 311, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<bool>("IsOwner");

                    b.Property<Guid>("ProjectId");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUsers");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.TechnologyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProjectId");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("GitHubUsername");

                    b.Property<string>("HashedPassword");

                    b.Property<string>("Locale");

                    b.Property<bool>("LookingForProject");

                    b.Property<string>("MagicLoginToken");

                    b.Property<DateTimeOffset>("MagicLoginTokenExpiresAt");

                    b.Property<string>("ProfilePictureUrl");

                    b.Property<string>("Timezone");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ChatAppUserEntity", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectUserEntity", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.ProjectEntity", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Infrastructure.Persistence.Entities.UserEntity", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.TechnologyEntity", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.ProjectEntity", "Project")
                        .WithMany("ProjectTechnologies")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Infrastructure.Persistence.Entities.UserEntity", "User")
                        .WithMany("UserTechnologies")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
