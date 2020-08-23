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
    [Migration("20200823231629_AddExtendedMarkdownDescriptionToProjectEntity")]
    partial class AddExtendedMarkdownDescriptionToProjectEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ChatAppUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("WorkspaceId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("WorkspaceMemberId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkspaceId", "WorkspaceMemberId")
                        .IsUnique();

                    b.ToTable("ChatAppUsers");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CommunicationPlatformTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("CommunicationPlatforms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(6440), new TimeSpan(0, 0, 0, 0, 0)),
                            LogoUrl = "https://i.imgur.com/y3e8lL6.png",
                            Name = "slack",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(8650), new TimeSpan(0, 0, 0, 0, 0)),
                            LogoUrl = "https://i.imgur.com/BoARUGM.png",
                            Name = "discord",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 890, DateTimeKind.Unspecified).AddTicks(8660), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CommunicationPlatform")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CommunicationPlatformUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ExtendedMarkdownDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("LaunchDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("LookingForMembers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ProjectType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RepositoryUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Searchable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 886, DateTimeKind.Unspecified).AddTicks(9260), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Adtech",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 886, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Aerospace",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(2450), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Agriculture",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Analytics",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4310), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4960), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Augmented Reality",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(4970), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Biotech",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5870), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Community",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Construction",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6250), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6710), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Continuing Education",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(6710), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Crypto / Blockchain",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7330), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7730), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Developer Tools",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8160), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "E-Sports",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8160), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Education",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8590), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8970), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Energy",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(8970), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Entertainment",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9350), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Financial Services",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 887, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Fitness / Wellness",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Food/Beverage",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(760), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Freight",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Gaming",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Government",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Hard Tech",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Hardware",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Healthcare",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3390), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Insurance",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3400), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Language Learning",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(3750), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4140), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Lending / Loan Management",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4140), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Marketplace",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4490), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4890), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Media",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(4900), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Public Transportation",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5640), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Retail",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Recruiting/Talent",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Robotics",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Security",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Sourcing / Recruiting",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Transportation",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8210), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Travel/Tourism",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8210), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8560), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Virtual Reality",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8570), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"),
                            CreatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 0, 0, 0, 0)),
                            Type = "Other",
                            UpdatedAt = new DateTimeOffset(new DateTime(2020, 8, 23, 23, 16, 28, 888, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUsers");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.TechnologyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GitHubUsername")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Locale")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LookingForProject")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MagicLoginToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("MagicLoginTokenExpiresAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("ResetPasswordTokenExpiresAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Timezone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.ProjectUserEntity", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.ProjectEntity", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Persistence.Entities.UserEntity", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
