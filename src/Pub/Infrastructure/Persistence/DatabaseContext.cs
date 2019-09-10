using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Entities;
using System;

namespace Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasIndex(m => m.Email).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(m => m.Username).IsUnique();
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                SeedData.SeedAll(modelBuilder);
            }
        }
    }
}

