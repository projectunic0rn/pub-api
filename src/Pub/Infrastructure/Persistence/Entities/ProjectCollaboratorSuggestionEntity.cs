using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Persistence.Entities
{
    public class ProjectCollaboratorSuggestionEntity : IStorage<ProjectCollaboratorSuggestionEntity>
    {
        public Guid Id { get; set; }
        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }
        public Guid ProjectId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        private readonly string _connectionString;

        public ProjectCollaboratorSuggestionEntity()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public async Task<ProjectCollaboratorSuggestionEntity> CreateAsync(ProjectCollaboratorSuggestionEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await context.ProjectCollaboratorSuggestions.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAllAsync(Expression<Func<ProjectCollaboratorSuggestionEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var items = await context.ProjectCollaboratorSuggestions.Where(predicate).ToListAsync();
            context.ProjectCollaboratorSuggestions.RemoveRange(items);
            await context.SaveChangesAsync();
        }

        public Task<List<ProjectCollaboratorSuggestionEntity>> FindAllAsync(Expression<Func<ProjectCollaboratorSuggestionEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectCollaboratorSuggestionEntity> FindAsync(Expression<Func<ProjectCollaboratorSuggestionEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectCollaboratorSuggestionEntity>> FindAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectCollaboratorSuggestionEntity> UpdateAsync(ProjectCollaboratorSuggestionEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
