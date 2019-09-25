using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void SeedAll(ModelBuilder modelBuilder, string env)
        {
            if (env == "Development")
            {
                SeedUsers(modelBuilder);
            }
            
            SeedProjectTypes(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            // TODO: Include seed data for users
        }

        private static void SeedProjectTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTypeEntity>().HasData(GetProjectTypeSeedData());
        }

        private static List<ProjectTypeEntity> GetProjectTypeSeedData()
        {
            List<ProjectTypeEntity> projectTypes = new List<ProjectTypeEntity>(){
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d00"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Adtech" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d01"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Aerospace" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d02"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Agriculture" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d03"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Analytics" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d04"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Augmented Reality" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d05"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Biotech" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d06"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Community" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d07"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Construction" },
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d08"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Continuing Education"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d09"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Crypto / Blockchain"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Developer Tools"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0b"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "E-Sports"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0c"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Education"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0d"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Energy"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0e"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Entertainment"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d0f"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Financial Services"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d10"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Fitness / Wellness"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d11"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Food/Beverage"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d12"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Freight"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d13"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Gaming"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d14"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Government"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d15"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Hard Tech"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d16"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Hardware"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d17"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Healthcare"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d18"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Insurance"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d19"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Language Learning"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Lending / Loan Management"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1b"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Marketplace"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1c"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Media"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1d"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Public Transportation"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1e"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Retail"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d1f"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Recruiting/Talent"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d20"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Robotics"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d21"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Security"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d22"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Sourcing / Recruiting"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d23"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Transportation"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d24"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Travel/Tourism"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d25"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Virtual Reality"},
                new ProjectTypeEntity { Id = new Guid("980d9433-547c-4e82-b3d5-c9f313505d26"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Type = "Other"}
            };

            return projectTypes;
        }

    }
}
