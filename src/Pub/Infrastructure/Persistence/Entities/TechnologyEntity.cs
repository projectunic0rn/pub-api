using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistence.Entities
{
    public class TechnologyEntity : IStorage<TechnologyEntity>
    {
        private readonly string _connectionString;
        public TechnologyEntity()
        {
            _connectionString = AppSettings.ConnectionString;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }
        public Guid? ProjectId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public Guid? UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<TechnologyEntity> CreateAsync(TechnologyEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await context.Technologies.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var tech = new TechnologyEntity { Id = id };
            context.Technologies.Attach(tech);
            context.Technologies.Remove(tech);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<TechnologyEntity> technologies)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            context.Technologies.RemoveRange(technologies);
            await context.SaveChangesAsync();
        }

        public async Task<List<TechnologyEntity>> FindAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<TechnologyEntity> items = await context.Technologies.ToListAsync();
            return items;
        }

        public async Task<TechnologyEntity> FindAsync(Expression<Func<TechnologyEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            TechnologyEntity item = await context.Technologies.SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<TechnologyEntity> UpdateAsync(TechnologyEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.UpdatedAt = DateTimeOffset.UtcNow;

            context.Technologies.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<List<ProjectTechnologies>> GetProjectTechnologiesAsync(params string[] technologyNames)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var query = from p in context.Set<ProjectEntity>()
                        join t in context.Set<TechnologyEntity>()
                        on p.Id equals t.ProjectId
                        where p.Searchable && p.LookingForMembers && technologyNames.Contains(t.Name)
                        select new ProjectTechnologies
                        {
                            Id = p.Id,
                            ProjectName = p.Name,
                            ProjectDescription = p.Description,
                            ProjectWorkspaceLink = p.CommunicationPlatformUrl,
                            TechnologyName = t.Name,
                            CreatedAt = t.CreatedAt
                        };

            var entities = await query.ToListAsync();
            return entities;
        }

        public async Task<List<DeveloperTechnologies>> GetDeveloperTechnologiesAsync(params string[] technologyNames)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var query = from u in context.Set<UserEntity>()
                        join t in context.Set<TechnologyEntity>()
                            on u.Id equals t.UserId
                        where technologyNames.Contains(t.Name) && u.LookingForProject
                        select new DeveloperTechnologies
                        {
                            UserId = u.Id,
                            CreatedAt = t.CreatedAt,
                            Name = t.Name,
                            Bio = u.Bio,
                        };

            var entities = await query.ToListAsync();
            return entities;
        }

        public Task<List<TechnologyEntity>> FindAllAsync(Expression<Func<TechnologyEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(Expression<Func<TechnologyEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
