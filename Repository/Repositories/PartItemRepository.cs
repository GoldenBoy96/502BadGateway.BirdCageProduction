using BusinessObject.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PartItemRepository : BaseRepository<PartItem>, IPartItemRepository
    {
        public PartItemRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PartItem>> GetPartItems()
        {
            return _context.PartItems.Include(pit => pit.Part).ToList();
        }
    }
}
