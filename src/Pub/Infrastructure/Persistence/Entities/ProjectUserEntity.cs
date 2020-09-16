using System;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistence.Entities
{
    public class ProjectUserEntity : IStorage<ProjectUserEntity>
    {
        private readonly string _connectionString;
        public ProjectUserEntity()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public Guid Id { get; set; }
        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }
        public Guid ProjectId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public bool IsOwner { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<ProjectUserEntity> CreateAsync(ProjectUserEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await context.ProjectUsers.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public Task DeleteAllAsync(Expression<Func<ProjectUserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var projectType = new ProjectUserEntity { Id = id };
            context.ProjectUsers.Attach(projectType);
            context.ProjectUsers.Remove(projectType);
            await context.SaveChangesAsync();
        }

        public Task<List<ProjectUserEntity>> FindAllAsync(Expression<Func<ProjectUserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProjectUserEntity>> FindAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<ProjectUserEntity> items = await context.ProjectUsers
                .Include(p => p.User)
                .ToListAsync();
            return items;
        }

        public async Task<ProjectUserEntity> FindAsync(Expression<Func<ProjectUserEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            ProjectUserEntity item = await context.ProjectUsers
                .Include(p => p.User)
                .SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<ProjectUserEntity> UpdateAsync(ProjectUserEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.UpdatedAt = DateTimeOffset.UtcNow;

            context.ProjectUsers.Update(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
