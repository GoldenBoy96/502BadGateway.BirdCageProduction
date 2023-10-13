﻿using DataAccess;
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
    }
}