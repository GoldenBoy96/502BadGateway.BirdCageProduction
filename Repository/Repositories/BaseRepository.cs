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
        private readonly DbSet<T> _dbSet;

        public BaseRepository(BirdCageProductionContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        //public BirdCageProductionContext Context { get { return _context; } }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
