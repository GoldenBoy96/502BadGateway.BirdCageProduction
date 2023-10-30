﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IAccountStatusRepository : IBaseRepository<AccountStatus>
    {
        public IEnumerable<AccountStatus> GetAll();
    }
}
