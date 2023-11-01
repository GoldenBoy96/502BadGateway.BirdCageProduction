using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        public Task<List<OrderDetail>> GetByOrderIdAsync(int orderId);
        public Task<List<OrderDetail>> GetAllAsync();

        public  Task<OrderDetail> FindByIdAsync(int id);
    }
}
