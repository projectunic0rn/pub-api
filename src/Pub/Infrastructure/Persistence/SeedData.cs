using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void SeedAll(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            // TODO: Include seed data for users
        }
    }
}
