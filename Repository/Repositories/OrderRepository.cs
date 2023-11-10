using BusinessObject.Models;
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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(BirdCageProductionContext context) : base(context)
        {           

        }

        public new async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet
                .Include(o => o.Account)
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        public new Order? GetById(int? id)
        {
            Order? result = _dbSet.FindAsync(id).Result;
            result.OrderDetails = _context.OrderDetails.Where(orderDetail => orderDetail.OrderId.Equals(result.OrderId))
                .Include(o => o.BirdCage)
                .Include(o => o.Order).ToListAsync().Result;
            return result;
        }

        public new async Task<bool> RemoveAsync(Order entity)
        {
            foreach (var item in _context.OrderDetails) {
                if (item.OrderId.Equals(entity.OrderId))
                {
                    _context.OrderDetails.Remove(item);
                }
            }

            _dbSet.Remove(entity);
            int success = await _context.SaveChangesAsync();
            return await Task.FromResult(success == 1);
        }
        
        public new async Task<bool> UpdateAsync(Order entity)
        {
            _context.Attach(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(entity.OrderId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
