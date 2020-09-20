using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Common.AppSettings;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Entities
{
    public class ChatAppUserEntity : IStorage<ChatAppUserEntity>
    {
        private readonly string _connectionString;

        public ChatAppUserEntity()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public Guid Id { get; set; }
        public string WorkspaceId { get; set; }
        public string WorkspaceMemberId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<ChatAppUserEntity> CreateAsync(ChatAppUserEntity item)
        {
            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            await context.ChatAppUsers.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var item = new ChatAppUserEntity { Id = id };
            context.ChatAppUsers.Attach(item);
            context.ChatAppUsers.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<List<ChatAppUserEntity>> FindAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<ChatAppUserEntity> items = await context.ChatAppUsers.Include(c => c.User).ThenInclude(u => u.UserTechnologies).ToListAsync();
            return items;
        }

        public async Task<ChatAppUserEntity> FindAsync(Expression<Func<ChatAppUserEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            ChatAppUserEntity item = await context.ChatAppUsers.Include(c => c.User).ThenInclude(u => u.UserTechnologies).SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<ChatAppUserEntity> UpdateAsync(ChatAppUserEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.UpdatedAt = DateTimeOffset.UtcNow;

            context.ChatAppUsers.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<List<DeveloperTechnologies>> GetDeveloperTechnologiesAsync(params string[] technologyNames)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var query = from c in context.Set<ChatAppUserEntity>()
            join t in context.Set<TechnologyEntity>()
                on c.UserId equals t.UserId
                where technologyNames.Contains(t.Name)
            select new DeveloperTechnologies
            {
                UserId = c.UserId,
                CreatedAt = t.CreatedAt,
                Name = t.Name,
                WorkspaceMemberId = c.WorkspaceMemberId
            };

            var entities = await query.ToListAsync();
            return entities;
        }

        public Task<List<ChatAppUserEntity>> FindAllAsync(Expression<Func<ChatAppUserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(Expression<Func<ChatAppUserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
