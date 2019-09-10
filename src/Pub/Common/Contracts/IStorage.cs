using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IStorage<T> where T : class
    {
        Task<T> CreateAsync(T item);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
