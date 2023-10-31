using BusinessLogic.Models.PartItem;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Add(BirdCage birdCage, List<PartItemPageModel> partItems)
        {
            foreach (var partItem in partItems) 
            {
                birdCage.PartItems
                        .Add(new PartItem
                        {
                            Quantity = partItem.Quantity,
                            PartId = unitOfWork.PartRepository.GetPartByCode(partItem.Code).Result.PartId
                        });
                
            }

            return await unitOfWork.BirdCageRepository.AddAsync(birdCage);          
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
