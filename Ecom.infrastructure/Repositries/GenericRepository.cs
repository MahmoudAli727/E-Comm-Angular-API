using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecom.infrastructure.Repositries
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(AppDbContext cdbCntext)
        {
            _dbCntext = cdbCntext;
        }
        private readonly AppDbContext _dbCntext;
        
        public async Task AddAsync(T entity)
        {
            await _dbCntext.Set<T>().AddAsync(entity);
            await _dbCntext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return  await _dbCntext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] Includes)
        {
            IQueryable<T> query = _dbCntext.Set<T>().AsQueryable();
           
            foreach (var inc in Includes)
            {
                query = query.Include(inc);
            }

            return await query.AsNoTracking().ToListAsync();

        }

        public async Task<T?> GetByIdAsync(int Id)
        {
            return await _dbCntext.Set<T>().FindAsync(Id);
        }

        public void Update(T entity)
        {
            _dbCntext.Set<T>().Update(entity);
            _dbCntext.SaveChanges();
        }

       async void  IGenericRepository<T>.Delete(int Id)
        {
            var enrity = await _dbCntext.Set<T>().FindAsync(Id);
            _dbCntext.Set<T>().Remove(enrity);
            await _dbCntext.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(int Id, params Expression<Func<T, object>>[] Includes)
        {
            IQueryable<T> query = _dbCntext.Set<T>();

            foreach (var inc in Includes)
            {
                query = query.Include(inc);
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id);
        }
    }
}
