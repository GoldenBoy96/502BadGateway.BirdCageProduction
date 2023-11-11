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
        public Task<IEnumerable<BirdCage>> GetAllBirdCageAsync();
        public Task<OrderDetail> GetOrderDetailByIdAsync(int id);
        public Task<bool> DeleteOrderDetailAsync(OrderDetail orderDetail);
        public Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail);

        public Task<IEnumerable<Order>> GetAllOrderAsync();
        public Task<Order?> GetOrderByIdAsync(int OrderId);
        public Task<bool> AddOrderAsync(Order order);
        public Task<bool> DeleteOrderAsync(Order order);
        public Task<bool> UpdateOrderAsync(Order order);
        Task<Order> MoveToNextStatus(int orderId);
    }
}
