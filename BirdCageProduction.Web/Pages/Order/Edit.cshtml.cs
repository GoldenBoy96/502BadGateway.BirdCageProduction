using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;
using BusinessLogic.Service.Abstraction;

namespace BirdCageProduction.Web.Pages.Order
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public string Message { get; set; }
        public EditModel(IOrderService orderService, IAccountService accountService, ICustomerService customerService)
        {
            _orderService = orderService;
            _accountService = accountService;
            _customerService = customerService;
        }

        [BindProperty]
        public BusinessObject.Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var orders = await _orderService.GetAllOrderAsync();
            if (id == null || orders == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderByIdAsync((int)id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            Order.OrderDetails = (ICollection<OrderDetail>)_orderService.GetAllOrderDetailOfAnOrderAsync((int)id).Result;
            ViewData["AccountId"] = new SelectList(_accountService.GetAllAccountsAsync().Result, "AccountId", "AccountId");
            ViewData["CustomerId"] = new SelectList(_customerService.GetAllCustomerAsync().Result, "CustomerId", "CustomerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                bool success = await _orderService.UpdateOrderAsync(Order);
                if (!success)
                {
                    Message = "Error while saving!";
                }
                Message = "Saved Successfully";
            }
            catch (Exception ex)
            {
                if (!await OrderExists(Order.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return RedirectToPage("./Index");
        }


        private async Task<bool> OrderExists(int? id)
        {
            BusinessObject.Models.Order? order = await _orderService.GetOrderByIdAsync((int)id);
            return order != null;
        }
    }
}
