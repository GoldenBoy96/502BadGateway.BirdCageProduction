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
using Repository.UnitOfWork;

namespace BirdCageProduction.Web.Pages.Order.OrderDetailPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IOrderService orderService,IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
        ViewData["BirdCageId"] = new SelectList(_orderService.GetAllBirdCageAsync().Result, "BirdCageId", "BirdCageId");
        ViewData["OrderId"] = new SelectList(_orderService.GetAllOrderAsync().Result, "OrderId", "OrderId");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var orderDetail = await _orderService.GetAllOrderDetailAsync();
            if (!ModelState.IsValid || orderDetail == null || OrderDetail == null)
            {
                return Page();
            }

            await _orderService.AddOrderDetailAsync(OrderDetail);

            return RedirectToPage("../Index");
        }
    }
}
