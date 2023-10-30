using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IColorService
    {
        Task<List<string>> ListColorName();
        Task<int> ReturnIdByName(string name);
    }
}
