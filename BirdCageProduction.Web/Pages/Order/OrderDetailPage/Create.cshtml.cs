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
using BusinessLogic.Service.Implementation;

namespace BirdCageProduction.Web.Pages.Order.OrderDetailPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;

        public CreateModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult OnGet()
        {
        ViewData["BirdCage"] = new SelectList(_orderService.GetAllBirdCageAsync().Result, "BirdCageId", "BirdCageId");
        ViewData["OrderId"] = new SelectList(_orderService.GetAllOrderAsync().Result, "OrderId", "OrderId");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _orderService.GetAllOrderDetailAsync() == null || OrderDetail == null)
            {
                return Page();
            }

            await _orderService.AddOrderDetailAsync(OrderDetail);
            //_context.OrderDetails.Add(OrderDetail);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
