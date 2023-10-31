using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IColorRepository : IBaseRepository<Color>
    {
        Task<List<string>> ColorsName();
        Task<int> ReturnIdByName(string name);

        public IEnumerable<Color> GetAll();
    }
}
