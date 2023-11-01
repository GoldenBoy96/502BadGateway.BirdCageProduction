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
        //public async Task<T?> GetByIdAsync(int? id)
        //{
        //    return await _dbSet.FindAsync(id);
        //}

        //public async Task<bool> RemoveAsync(T entity)
        //{
        //    _dbSet.Remove(entity);
        //    int success = await _context.SaveChangesAsync();
        //    return await Task.FromResult(success == 1);
        //}

        //public async Task<bool> UpdateAsync(T entity)
        //{
        //    _dbSet.Attach(entity);
        //    _context.Entry(entity).State = EntityState.Modified;
        //    int success = await _context.SaveChangesAsync();
        //    return await Task.FromResult(success == 1);
        //}

        public async Task<IEnumerable<BirdCage>> GetAllBirdCageAsync()
        {
            return await _unitOfWork.BirdCageRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllAsync();
        }


    }
}
