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
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;


        public DeleteModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [BindProperty]
      public Account Account { get; set; } = default!;
        public string Message { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
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

                bool success = await _accountService.DeleteAccountAsync(account);
                if (success)
                {
                    Message = "Save Successfully";
                    return Page();
                }
                Message = "Save failed";
                return Page();
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }
    }
}
