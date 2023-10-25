﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IAuthService
    {
        Task<bool> Login (string email, string password);
        Task LogOut();
    }
}
