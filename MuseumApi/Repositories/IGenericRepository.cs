using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
namespace MuseumApi.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Find(Guid id);
        Task<List<T>> FindAll();
        Task<List<T>> FindBy(Expression<Func<T, bool>> expression);
        Task<T> FindOneBy(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}