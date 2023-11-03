using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using DataAccess;
using BusinessLogic.Service.Abstraction;

namespace BirdCageProduction.Web.Pages.Order
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public CreateModel(IOrderService orderService, IAccountService accountService, ICustomerService customerService)
        {
            _orderService = orderService;
            _accountService = accountService;
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            ViewData["AccountId"] = new SelectList(_accountService.GetAllAccountsAsync().Result, "AccountId", "AccountId");
            ViewData["CustomerId"] = new SelectList(_customerService.GetCustomers().Result, "CustomerId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.Order Order { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _orderService.GetAllOrderAsync().Result == null || Order == null)
            {
                return Page();
            }

            await _orderService.AddOrderAsync(Order);

            return RedirectToPage("./Index");
        }
    }
}
