using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;

namespace BirdCageProduction.Web.Pages.Order
{
    public class DetailsModel : PageModel
    {
        private readonly BirdCageProductionContext _context;

        public DetailsModel(BirdCageProductionContext context)
        {
            _context = context;
        }

        public BusinessObject.Models.Order Order { get; set; } = default!;
        public BusinessObject.Models.OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
                Order.OrderDetails = _context.OrderDetails.Where(orderDetail => orderDetail.OrderId.Equals(id))
                .Include(o => o.BirdCage)
                .Include(o => o.Order).ToList();

            }
            return Page();
        }
    }
}
