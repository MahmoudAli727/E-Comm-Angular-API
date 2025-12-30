
using System.Linq.Expressions;

namespace Ecom.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] Includes);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(int Ids);
        Task<T?> GetByIdAsync(int Id);
        Task<T?> GetByIdAsync(int Id, params Expression<Func<T, object>>[] Includes);
        //Task SaveChangesAsync();
    }
}
