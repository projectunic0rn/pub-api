using System;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities
{
    public class ProjectTypeEntity : IStorage<ProjectTypeEntity>
    {
        private readonly DatabaseContext _context;
        public ProjectTypeEntity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            _context = new DatabaseContext(optionsBuilder.Options);
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<ProjectTypeEntity> CreateAsync(ProjectTypeEntity item)
        {
            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.ProjectTypes.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(ProjectTypeEntity item)
        {
            var projectType = new ProjectTypeEntity { Id = item.Id };
            _context.ProjectTypes.Attach(projectType);
            _context.ProjectTypes.Remove(projectType);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProjectTypeEntity>> FindAsync()
        {
            List<ProjectTypeEntity> items = await _context.ProjectTypes.ToListAsync();
            return items;
        }

        public async Task<ProjectTypeEntity> FindAsync(Expression<Func<ProjectTypeEntity, bool>> predicate)
        {
            ProjectTypeEntity item = await _context.ProjectTypes.SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<ProjectTypeEntity> UpdateAsync(ProjectTypeEntity item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;

            _context.ProjectTypes.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
