using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BirdCageProduction.Web.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<BusinessObject.Models.Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Order = (IList<BusinessObject.Models.Order>)await _orderService.GetAllOrderAsync();
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
          
            

        }

        public RedirectToPageResult OnGetById(int id)
        {

            return RedirectToPage($"./Edit?id={id}");

        }




    }
}
