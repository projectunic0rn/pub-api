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
        private readonly DatabaseContext _context;
        public ProjectEntity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            _context = new DatabaseContext(optionsBuilder.Options);
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
            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.Projects.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var projectType = new ProjectEntity { Id = id };
            _context.Projects.Attach(projectType);
            _context.Projects.Remove(projectType);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProjectEntity>> FindAsync()
        {
            List<ProjectEntity> items = await _context.Projects
                .Include(p => p.ProjectTechnologies)
                .Include(p => p.ProjectUsers)
                .ThenInclude(p => p.User)
                .Where(p => p.Searchable && p.LookingForMembers)
                .ToListAsync();
            return items;
        }

        public async Task<List<ProjectEntity>> FindAllAsync()
        {
            List<ProjectEntity> items = await _context.Projects
                .Include(p => p.ProjectTechnologies)
                .Include(p => p.ProjectUsers)
                .ThenInclude(p => p.User)
                .ToListAsync();
            return items;
        }

        public async Task<ProjectEntity> FindAsync(Expression<Func<ProjectEntity, bool>> predicate)
        {
            ProjectEntity item = await _context.Projects
                .Include(p => p.ProjectTechnologies)
                .Include(p => p.ProjectUsers)
                .ThenInclude(p => p.User)
                .SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<ProjectEntity> UpdateAsync(ProjectEntity item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;
            
            _context.Projects.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
