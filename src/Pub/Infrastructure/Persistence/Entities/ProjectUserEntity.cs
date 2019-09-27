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
        private readonly DatabaseContext _context;
        public ProjectUserEntity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            _context = new DatabaseContext(optionsBuilder.Options);
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
            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.ProjectUsers.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var projectType = new ProjectUserEntity { Id = id };
            _context.ProjectUsers.Attach(projectType);
            _context.ProjectUsers.Remove(projectType);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProjectUserEntity>> FindAsync()
        {
            List<ProjectUserEntity> items = await _context.ProjectUsers
                .Include(p => p.User)
                .ToListAsync();
            return items;
        }

        public async Task<ProjectUserEntity> FindAsync(Expression<Func<ProjectUserEntity, bool>> predicate)
        {
            ProjectUserEntity item = await _context.ProjectUsers
                .Include(p => p.User)
                .SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<ProjectUserEntity> UpdateAsync(ProjectUserEntity item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;

            _context.ProjectUsers.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
