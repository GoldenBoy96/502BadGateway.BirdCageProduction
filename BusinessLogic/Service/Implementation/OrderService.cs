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

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<bool> DeleteOrderDetailAsync(OrderDetail orderDetail)
        {
            return await _unitOfWork.OrderDetailRepository.RemoveAsync(orderDetail);
        }

        public async Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            return await _unitOfWork.OrderDetailRepository.UpdateAsync(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
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

        public async Task<Order> MoveToNextStatus(int orderId)
        {
            Order order = await GetOrderByIdAsync(orderId);
            System.Diagnostics.Debug.WriteLine(orderId + "     "+ order + " ======================================================================================");

            switch (order.StatusId)
            {
                case 0:
                    order.StatusId += 1;
                    break;
                case 1:
                    order.StatusId += 1;
                    break;
                case 2:
                    bool isCompleteProducing = true;
                    foreach (OrderDetail orderDetail in order.OrderDetails)
                    {
                        foreach (Progress progress in orderDetail.Progresses)
                        {
                            if (progress.StatusId != 2)
                            {
                                isCompleteProducing = false;
                                break;
                            }
                        }
                    }
                    if (isCompleteProducing)
                    {
                        order.StatusId += 1;
                    }
                    break;
                case 3:
                    order.StatusId += 1;
                    break;
                case 4:
                    order.StatusId += 1;
                    break;
                case 5:
                    //Do nothing
                    break;
            }
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            return order;

        }


    }
}
