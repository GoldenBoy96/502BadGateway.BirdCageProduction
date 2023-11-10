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
    public class ProgressService : IProgressService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProgressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> AddProgressAsync(Progress order)
        {
            return unitOfWork.ProgressRepository.AddAsync(order);
        }

        public Task<bool> DeleteProgressAsync(Progress order)
        {
            return unitOfWork.ProgressRepository.RemoveAsync(order);
        }

        public Task<IEnumerable<Progress>> GetAllProgressAsync()
        {
            return unitOfWork.ProgressRepository.GetAllAsync();
        }

        public Task<Progress?> GetProgressByIdAsync(int ProgressId)
        {
            return unitOfWork.ProgressRepository.GetById(ProgressId);
        }

        public Task<bool> UpdateProgressAsync(Progress order)
        {
            return unitOfWork.ProgressRepository.UpdateAsync(order);
        }


    }
}
