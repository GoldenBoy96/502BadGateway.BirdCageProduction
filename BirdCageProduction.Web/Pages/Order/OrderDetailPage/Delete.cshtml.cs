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

namespace BirdCageProduction.Web.Pages.Order.OrderDetailPage
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderService _orderService;

        public DeleteModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
      public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _orderService.GetAllOrderDetailAsync() == null)
            {
                return NotFound();
            }
            var orderdetail = _orderService.FindOrderDetailByIdAsync((int)id);

            if (orderdetail == null)
            {
                return NotFound();
            }
            else 
            {
                OrderDetail = orderdetail.Result;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _orderService.GetAllOrderDetailAsync() == null)
            {
                return NotFound();
            }
            var orderdetail = _orderService.FindOrderDetailByIdAsync((int)id);

            if (orderdetail != null)
            {
                OrderDetail = orderdetail.Result;
                //_context.OrderDetails.Remove(OrderDetail);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
