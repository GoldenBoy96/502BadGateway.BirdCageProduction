using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailOfAnOrderAsync(int orderId)
        {

            return await _unitOfWork.OrderDetailRepository.GetByOrderIdAsync(orderId);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync()
        {
            return await _unitOfWork.OrderDetailRepository.GetAllAsync();
        }

        public async Task<bool> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            return await _unitOfWork.OrderDetailRepository.AddAsync(orderDetail);
        }


        public async Task<OrderDetail> FindOrderDetailByIdAsync(int id)
        {
            return await _unitOfWork.OrderDetailRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<BirdCage>> GetAllBirdCageAsync()
        {
            return await _unitOfWork.BirdCageRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _unitOfWork.OrderRepository.GetById(orderId);
        }


        public async Task<bool> AddOrderAsync(Order order)
        {
            return await _unitOfWork.OrderRepository.AddAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(Order order)
        {
            return await _unitOfWork.OrderRepository.RemoveAsync(order);
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _unitOfWork.OrderRepository.UpdateAsync(order);
        }

        

        
    }
}
