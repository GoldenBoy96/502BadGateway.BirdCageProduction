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
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _orderService;

        public DetailsModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public OrderDetail OrderDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var orderdetails = await _orderService.GetAllOrderDetailAsync();
            if (id == null || orderdetails == null)
            {
                return NotFound();
            }

            var orderdetail = await _orderService.GetOrderDetailByIdAsync((int)id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            else 
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }
    }
}
