﻿using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IBirdCageRepository : IBaseRepository<BirdCage>
    {
        Task<BirdCage> FindByIdAsync(int id);
    }
}
