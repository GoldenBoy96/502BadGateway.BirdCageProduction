using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IProgressService
    {
        public Task<IEnumerable<Progress>> GetAllProgressAsync();
        public Task<Progress?> GetProgressByIdAsync(int progressId);
        public Task<bool> AddProgressAsync(Progress progress);
        public Task<bool> DeleteProgressAsync(Progress progress);
        public Task<bool> UpdateProgressAsync(Progress progress);
        Task<List<Progress>> GenerateProgressFromProcedure(OrderDetail orderdetail);
        Task<List<Progress>> GetByOrderDetailId(int orderDetailId);
    }
}


