using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public new Task<IEnumerable<Order>> GetAllAsync();
        public new  Task<Order?> GetById(int? id);
        public new  Task<bool> UpdateAsync(Order entity);
    }
}
