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

namespace BirdCageProduction.Web.Pages.AccountPage
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DetailsModel(IAccountService accountService)
        {
                   _accountService = accountService;
        }

      public Account Account { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            Account? account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
