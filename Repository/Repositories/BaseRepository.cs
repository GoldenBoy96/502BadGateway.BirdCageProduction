using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly BirdCageProductionContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(BirdCageProductionContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            int success = await _context.SaveChangesAsync();

            return await Task.FromResult(success == 1);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            int success = await _context.SaveChangesAsync();
            return await Task.FromResult(success == 1);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            int success = await _context.SaveChangesAsync();
            return await Task.FromResult(success == 1);
        }
    }
}