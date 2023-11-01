using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDetail>> GetAllOrderDetailOfAnOrderAsync(int orderId);
        public Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync();
        public Task<bool> AddOrderDetailAsync(OrderDetail orderDetail);
        public  Task<IEnumerable<BirdCage>> GetAllBirdCageAsync();

        public  Task<IEnumerable<Order>> GetAllOrderAsync();

        public Task<OrderDetail> FindOrderDetailByIdAsync(int id);
    }
}
