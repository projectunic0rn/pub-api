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

            SeedCommunicationPlatformTypes(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            // TODO: Include seed data for users
        }

        private static void SeedCommunicationPlatformTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunicationPlatformTypeEntity>().HasData(GetCommunicationPlatformSeedData());
        }

        private static List<CommunicationPlatformTypeEntity> GetCommunicationPlatformSeedData()
        {
            List<CommunicationPlatformTypeEntity> communicationPlatformTypes = new List<CommunicationPlatformTypeEntity>()
            {
                new CommunicationPlatformTypeEntity { Id = new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac0"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Name = "slack", LogoUrl = "https://i.imgur.com/kjyihvN.png" },
                new CommunicationPlatformTypeEntity { Id = new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Name = "discord", LogoUrl = "https://i.imgur.com/MehiKJX.png" },
                new CommunicationPlatformTypeEntity { Id = new Guid("7d73c8aa-055c-4702-b825-0e8fb4e77ac1"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, Name = "other", LogoUrl = "https://i.imgur.com/887QGU1.png" },
            };

            return communicationPlatformTypes;
        }
    }
}
