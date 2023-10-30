using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using Repository.UnitOfWork;

namespace BirdCageProduction.Web.Pages.AccountPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _service;

        public IndexModel(IAccountService service)
        {
            _service = service;
        }
        public List<Account> Account { get; set; }

        public async Task OnGetAsync()
        {
            if (_service != null)
            {
                Account = (List<Account>) await _service.GetAllAccountsAsync();
            }
        }
    }
}
