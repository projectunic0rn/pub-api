using System;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Infrastructure.Persistence.Entities
{
    public class ProjectEntity : IStorage<ProjectEntity>
    {
        private readonly string _connectionString;
        public ProjectEntity()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExtendedMarkdownDescription { get; set; }
        public DateTimeOffset LaunchDate { get; set; }
        public string ProjectType { get; set; }
        public string RepositoryUrl { get; set; }
        public string CommunicationPlatformUrl { get; set; }
        public bool LookingForMembers { get; set; }
        public string CommunicationPlatform { get; set; }
        public List<ProjectUserEntity> ProjectUsers { get; set; }
        public List<TechnologyEntity> ProjectTechnologies { get; set; }
        public bool Searchable { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<ProjectEntity> CreateAsync(ProjectEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await context.Projects.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var projectType = new ProjectEntity { Id = id };
            context.Projects.Attach(projectType);
            context.Projects.Remove(projectType);
            await context.SaveChangesAsync();
            return;
        }

        public async Task<List<ProjectEntity>> FindAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<ProjectEntity> items = await context.Projects
                .Include(p => p.ProjectTechnologies)
                .Include(p => p.ProjectUsers)
                .ThenInclude(p => p.User)
                .Where(p => p.Searchable && p.LookingForMembers)
                .ToListAsync();
            return items;
        }

        public async Task<List<ProjectEntity>> FindAllAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<ProjectEntity> items = await context.Projects
                .Include(p => p.ProjectTechnologies)
                .Include(p => p.ProjectUsers)
                .ThenInclude(p => p.User)
                .ToListAsync();
            return items;
        }

        public async Task<ProjectEntity> FindAsync(Expression<Func<ProjectEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);

            using var context = new DatabaseContext(optionsBuilder.Options);
            ProjectEntity item = await context.Projects
                           .Include(p => p.ProjectTechnologies)
                           .Include(p => p.ProjectUsers)
                           .ThenInclude(p => p.User)
                           .SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<ProjectEntity> UpdateAsync(ProjectEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.UpdatedAt = DateTimeOffset.UtcNow;
            context.Projects.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public Task<List<ProjectEntity>> FindAllAsync(Expression<Func<ProjectEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
