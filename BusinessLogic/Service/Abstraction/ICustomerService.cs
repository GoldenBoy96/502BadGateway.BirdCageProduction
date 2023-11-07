using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAllCustomerAsync();
        public Task<Customer?> GetCustomerByIdAsync(int CustomerId);
        public Task<bool> AddCustomerAsync(Customer order);
        public Task<bool> DeleteCustomerAsync(Customer order);
        public Task<bool> UpdateCustomerAsync(Customer order);
    }
}
