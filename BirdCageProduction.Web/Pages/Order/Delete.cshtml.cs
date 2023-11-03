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

namespace BirdCageProduction.Web.Pages.Order
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderService _orderService;


        public DeleteModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public BusinessObject.Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _orderService.GetAllOrderAsync().Result == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderByIdAsync((int)id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            BusinessObject.Models.Order? order = null;
            try
            {
                order = await _orderService.GetOrderByIdAsync((int)id);
            }catch (Exception ex)
            {
                return NotFound();
            }
            

            if (order != null)
            {
                Order = order;
                await _orderService.DeleteOrderAsync(Order);
            }

            return RedirectToPage("./Index");
        }
    }
}
