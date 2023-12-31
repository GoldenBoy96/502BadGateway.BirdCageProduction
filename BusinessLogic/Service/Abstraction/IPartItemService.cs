﻿using BusinessLogic.Models.PartItem;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IPartItemService
    {
        Task<bool> Add(PartItemPageModel model);
        Task<IEnumerable<PartItem>> GetPartItems();
    }
}
