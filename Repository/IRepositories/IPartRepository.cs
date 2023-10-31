using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IPartRepository : IBaseRepository<Part>
    {
        Task<IEnumerable<string?>> GetPartCodes();

        Task<Part?> GetPartByCode(string code);
    }
}
