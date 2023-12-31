﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account?> GetByEmail(string email);
        Task<Account?> LoginAsync(string email, string password);
    }
}
