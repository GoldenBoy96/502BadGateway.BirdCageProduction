﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<bool> CustomerExists(int id);
    }
}
