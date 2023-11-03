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
    public class PartRepository : BaseRepository<Part>, IPartRepository
    {
        public PartRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public Task<Part?> GetPartByCode(string code)
        {
            return _context.Parts.FirstOrDefaultAsync(p => p.Code.Equals(code));
        }

        public async Task<IEnumerable<string>> GetPartCodes()
        {
            return await _context.Parts.Select(p => p.Code).ToListAsync();
        }


    }
}
