using BusinessLogic.Models.PartItem;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
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

        public async Task<bool> DeleteBirdCage(int id)
        {
            var entity = await unitOfWork.BirdCageRepository.FindByIdAsync(id);
            return await unitOfWork.BirdCageRepository.RemoveAsync(entity);
        }

        public async Task<bool> EditBirtCage(BirdCage birdCage, List<PartItemPageModel> partItems)
        {
            var mapPartItems = new List<PartItem>();
            foreach (var partItem in partItems)
            {
                mapPartItems.Add(new PartItem
                                {
                                    Quantity = partItem.Quantity,
                                    PartId = unitOfWork.PartRepository.GetPartByCode(partItem.Code).Result.PartId
                                });

            }
            birdCage = await unitOfWork.BirdCageRepository.FindByIdAsync(birdCage.BirdCageId);
            birdCage.PartItems = new List<PartItem>(mapPartItems);

            return await unitOfWork.BirdCageRepository.UpdateAsync(birdCage);   
        }

        public async Task<BirdCage> GetBirdCageById(int id)
        {
            return await unitOfWork.BirdCageRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<BirdCage>> GetBirdCages()
        {
            return await unitOfWork.BirdCageRepository.GetAllAsync();
        }
    }
}
