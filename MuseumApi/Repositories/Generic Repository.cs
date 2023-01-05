using System.Threading.Tasks;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using MuseumApi.DAL;


namespace MuseumApi.Repositories

{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MuseumContext _context;
        public GenericRepository(MuseumContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> FindBy(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();

        }
        public async Task<T> FindOneBy(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).FirstAsync();
        }
        public async Task<List<T>> FindAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> Find(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    }
}