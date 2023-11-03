using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;
using Repository.IRepositories;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;

namespace BirdCageProduction.Web.Pages.Order.OrderDetailPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {

            OrderDetail = (IList<OrderDetail>)await _orderService.GetAllOrderDetailOfAnOrderAsync(1);
            
        }

        
    }
}
