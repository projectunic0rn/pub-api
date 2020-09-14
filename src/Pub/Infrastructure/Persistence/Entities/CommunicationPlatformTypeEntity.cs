using System;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities
{
    public class CommunicationPlatformTypeEntity : IStorage<CommunicationPlatformTypeEntity>
    {
        private readonly DatabaseContext _context;
        public CommunicationPlatformTypeEntity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            _context = new DatabaseContext(optionsBuilder.Options);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<CommunicationPlatformTypeEntity> CreateAsync(CommunicationPlatformTypeEntity item)
        {
            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.CommunicationPlatforms.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task DeleteAllAsync(Expression<Func<CommunicationPlatformTypeEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var communicationPlatformType = new CommunicationPlatformTypeEntity { Id = id };
            _context.CommunicationPlatforms.Attach(communicationPlatformType);
            _context.CommunicationPlatforms.Remove(communicationPlatformType);
            await _context.SaveChangesAsync();
        }

        public Task<List<CommunicationPlatformTypeEntity>> FindAllAsync(Expression<Func<CommunicationPlatformTypeEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommunicationPlatformTypeEntity>> FindAsync()
        {
            List<CommunicationPlatformTypeEntity> items = await _context.CommunicationPlatforms.ToListAsync();
            return items;
        }

        public async Task<CommunicationPlatformTypeEntity> FindAsync(Expression<Func<CommunicationPlatformTypeEntity, bool>> predicate)
        {
            CommunicationPlatformTypeEntity item = await _context.CommunicationPlatforms.SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<CommunicationPlatformTypeEntity> UpdateAsync(CommunicationPlatformTypeEntity item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;

            _context.CommunicationPlatforms.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
