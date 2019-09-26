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
        public DbSet<ProjectTypeEntity> ProjectTypes { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ProjectUserEntity> ProjectUsers { get; set; }
        public DbSet<CommunicationPlatformTypeEntity> CommunicationPlatforms { get; set; }
        public DbSet<TechnologyEntity> Technologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<ProjectEntity>().Property(p => p.LookingForMembers).HasDefaultValue(true);
            SeedData.SeedAll(modelBuilder, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }
    }
}

