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
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(BirdCageProductionContext context) : base(context)
        {

        }

        public async Task<OrderDetail> GetByIdAsync(int orderDetailId)
        {
            return await _context.OrderDetails.FindAsync(orderDetailId);
        }

        public  Task<List<OrderDetail>> GetByOrderIdAsync(int orderId)
        {
            return  _context.OrderDetails.Where(orderDetail => orderDetail.OrderId.Equals(orderId))
                .Include(o => o.BirdCage)
                .Include(o => o.Order).ToListAsync();
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _dbSet.Include(o => o.BirdCage)
                .Include(o => o.Order).ToListAsync(); ;
        }

        public async Task<OrderDetail> FindByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.OrderDetailId == id);
        }
    }
}
