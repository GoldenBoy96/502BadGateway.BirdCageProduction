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
        private readonly BirdCageProductionContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(BirdCageProductionContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        //public BirdCageProductionContext Context { get { return _context; } }

        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            int success = await _context.SaveChangesAsync();

            return await Task.FromResult(success == 1);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Remove(T entity)
        {
            _dbSet.Remove(entity);
            int success  =  await _context.SaveChangesAsync();
            return await Task.FromResult(success == 1);
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            int success = await _context.SaveChangesAsync();
            return await Task.FromResult(success == 1);
        }
    }
}
