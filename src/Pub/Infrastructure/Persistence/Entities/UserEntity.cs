using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.Linq;

namespace Infrastructure.Persistence.Entities
{
    public class UserEntity : IStorage<UserEntity>
    {
        private readonly DatabaseContext _context;

        public UserEntity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            _context = new DatabaseContext(optionsBuilder.Options);
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string HashedPassword { get; set; }
        public string Timezone { get; set; }
        public string Locale { get; set; }
        public bool LookingForProject { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string GitHubUsername { get; set; }
        public string MagicLoginToken { get; set; }
        public DateTimeOffset MagicLoginTokenExpiresAt { get; set; }
        public List<ProjectUserEntity> ProjectUsers { get; set; }
        public List<TechnologyEntity> UserTechnologies { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<UserEntity> CreateAsync(UserEntity item)
        {
            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = new UserEntity { Id = id };
            _context.Users.Attach(user);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserEntity>> FindAsync()
        {
            List<UserEntity> items = await _context.Users
            .Include(u => u.UserTechnologies)
            .Include(u => u.ProjectUsers)
            .ToListAsync();
            return items;
        }

        public async Task<UserEntity> FindAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            UserEntity item = await _context.Users
            .Include(u => u.UserTechnologies)
            .Include(u => u.ProjectUsers)
            .SingleOrDefaultAsync(predicate);
            return item;
        }

        // used to assign generated username 
        // with incrementing value
        public async Task<UserEntity> FindLastUnicornRecord()
        {
            UserEntity item = await _context.Users.OrderByDescending(u => u.CreatedAt).Where(u => u.Username.StartsWith("unicorn")).FirstOrDefaultAsync();
            return item;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
