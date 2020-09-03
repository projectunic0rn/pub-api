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
        private readonly DatabaseContext _context;
        public TechnologyEntity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            _context = new DatabaseContext(optionsBuilder.Options);
            
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
            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.Technologies.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var tech = new TechnologyEntity { Id = id };
            _context.Technologies.Attach(tech);
            _context.Technologies.Remove(tech);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<TechnologyEntity> technologies)
        {
            _context.Technologies.RemoveRange(technologies);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TechnologyEntity>> FindAsync()
        {
            List<TechnologyEntity> items = await _context.Technologies.ToListAsync();
            return items;
        }

        public async Task<TechnologyEntity> FindAsync(Expression<Func<TechnologyEntity, bool>> predicate)
        {
            TechnologyEntity item = await _context.Technologies.SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<TechnologyEntity> UpdateAsync(TechnologyEntity item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;

            _context.Technologies.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<ProjectTechnologies>> GetProjectTechnologiesAsync(params string[] technologyNames)
        {
            var query = from p in _context.Set<ProjectEntity>()
                        join t in _context.Set<TechnologyEntity>()
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

        public Task<List<TechnologyEntity>> FindAllAsync(Expression<Func<TechnologyEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
