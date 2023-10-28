using BusinessObject.Models;
using DataAccess;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public async Task<List<string>> ColorsName()
        {
            return _context.Colors.Select(c => c.ColorName).ToList();
        }

        public async Task<int> ReturnIdByName(string name)
        {
            return _context.Colors.FirstOrDefault(c => c.ColorName == name).ColorId;
        }
    }
}
