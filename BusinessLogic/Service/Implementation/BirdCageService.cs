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
    public class BirdCageService : IBirdCageService
    {
        private readonly IUnitOfWork unitOfWork;

        public BirdCageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<BirdCage> GetBirdCageById(int id)
        {
            return unitOfWork.BirdCageRepository.FindByIdAsync(id);
        }

        public Task<IEnumerable<BirdCage>> GetBirdCages()
        {
            return unitOfWork.BirdCageRepository.GetAllAsync();
        }
    }
}
