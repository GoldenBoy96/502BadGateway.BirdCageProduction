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
using static System.Runtime.InteropServices.JavaScript.JSType;
using BusinessLogic.Service.Abstraction;

namespace BirdCageProduction.Web.Pages.Order.OrderDetailPage
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _orderService;

        public EditModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
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
            OrderDetail = orderdetail;
            ViewData["BirdCageId"] = new SelectList(_orderService.GetAllBirdCageAsync().Result, "BirdCageId", "BirdCageId");
            ViewData["OrderId"] = new SelectList(_orderService.GetAllOrderAsync().Result, "OrderId", "OrderId");
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
                bool success = await _orderService.UpdateOrderDetailAsync(OrderDetail);
                if (!success)
                {
                    
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                bool success = await OrderDetailExists(OrderDetail.OrderDetailId);
                if (!success)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            int id = 1;
            //return RedirectToPage($"../Index?id={id}&handler=ById");
            //System.Diagnostics.Debug.WriteLine(Request.Headers["Referer"].ToString());
            return Redirect("../Index");
        }

        private async Task<bool> OrderDetailExists(int id)
        {
            BusinessObject.Models.OrderDetail? orderDtail = await _orderService.GetOrderDetailByIdAsync((int)id);
            return orderDtail != null;
        }
    }
}
