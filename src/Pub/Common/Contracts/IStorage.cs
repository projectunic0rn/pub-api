using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Common.Contracts
{
    public interface IStorage<T> where T : class
    {
        Task<T> CreateAsync(T item);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindAsync();
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(Guid id);
    }
}
