using BusinessLogic.Models.Part;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IPartService
    {
        Task<IEnumerable<Part>> GetParts();
        Task<PartOptions> GetPartOptions();
        Task AddPart(PartPageModel model);
        Task EditPart(PartPageModel model);
        Task<PartPageModel> GetPartById(int id);
    }
}
