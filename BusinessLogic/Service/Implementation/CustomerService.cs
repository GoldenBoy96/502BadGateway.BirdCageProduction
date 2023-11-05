using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Implementation
{
    public class CustomerService:ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> AddCustomerAsync(Customer order)
        {
            return unitOfWork.CustomerRepository.AddAsync(order);
        }

        public Task<bool> DeleteCustomerAsync(Customer order)
        {
            return unitOfWork.CustomerRepository.RemoveAsync(order);
        }

        public Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return unitOfWork.CustomerRepository.GetAllAsync();
        }

        public Task<Customer?> GetCustomerByIdAsync(int CustomerId)
        {
            return unitOfWork.CustomerRepository.GetById(CustomerId);
        }

        public Task<bool> UpdateCustomerAsync(Customer order)
        {
            return unitOfWork.CustomerRepository.UpdateAsync(order);
        }
    }
}
