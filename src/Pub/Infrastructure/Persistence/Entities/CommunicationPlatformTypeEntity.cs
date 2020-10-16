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
        private readonly string _connectionString;
        public CommunicationPlatformTypeEntity()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<CommunicationPlatformTypeEntity> CreateAsync(CommunicationPlatformTypeEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await context.CommunicationPlatforms.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public Task DeleteAllAsync(Expression<Func<CommunicationPlatformTypeEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var communicationPlatformType = new CommunicationPlatformTypeEntity { Id = id };
            context.CommunicationPlatforms.Attach(communicationPlatformType);
            context.CommunicationPlatforms.Remove(communicationPlatformType);
            await context.SaveChangesAsync();
        }

        public Task<List<CommunicationPlatformTypeEntity>> FindAllAsync(Expression<Func<CommunicationPlatformTypeEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommunicationPlatformTypeEntity>> FindAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<CommunicationPlatformTypeEntity> items = await context.CommunicationPlatforms.ToListAsync();
            return items;
        }

        public async Task<CommunicationPlatformTypeEntity> FindAsync(Expression<Func<CommunicationPlatformTypeEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            CommunicationPlatformTypeEntity item = await context.CommunicationPlatforms.SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<CommunicationPlatformTypeEntity> UpdateAsync(CommunicationPlatformTypeEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.UpdatedAt = DateTimeOffset.UtcNow;

            context.CommunicationPlatforms.Update(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
