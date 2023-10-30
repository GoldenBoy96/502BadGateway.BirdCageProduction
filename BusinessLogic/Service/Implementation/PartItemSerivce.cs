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
    public class PartItemSerivce : IPartItemService
    {
        private readonly IUnitOfWork unitOfWork;

        public PartItemSerivce(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<PartItem>> GetPartItems()
        {
            return unitOfWork.PartItemRepository.GetPartItems();
        }
    }
}
