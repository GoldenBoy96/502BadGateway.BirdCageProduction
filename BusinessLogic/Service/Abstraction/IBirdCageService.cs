using BusinessLogic.Models.PartItem;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IBirdCageService
    {
        Task<bool> Add(BirdCage birdCage, List<PartItemPageModel> partItems);
        Task<IEnumerable<BirdCage>> GetBirdCages();
        Task<BirdCage> GetBirdCageById(int id);
    }
}
