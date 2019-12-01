using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistence.Entities
{
    public class ChatAppUserEntity : IStorage<ChatAppUserEntity>
    {
        private readonly DatabaseContext _context;

        public ChatAppUserEntity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            _context = new DatabaseContext(optionsBuilder.Options);
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

            await _context.ChatAppUsers.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = new ChatAppUserEntity { Id = id };
            _context.ChatAppUsers.Attach(item);
            _context.ChatAppUsers.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ChatAppUserEntity>> FindAsync()
        {
            List<ChatAppUserEntity> items = await _context.ChatAppUsers.Include(c => c.User).ToListAsync();
            return items;
        }

        public async Task<ChatAppUserEntity> FindAsync(Expression<Func<ChatAppUserEntity, bool>> predicate)
        {
            ChatAppUserEntity item = await _context.ChatAppUsers.Include(c => c.User).SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<ChatAppUserEntity> UpdateAsync(ChatAppUserEntity item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;

            _context.ChatAppUsers.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}