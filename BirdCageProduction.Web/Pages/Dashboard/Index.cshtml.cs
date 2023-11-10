using BusinessLogic.Constant.StatusConstant;
using BusinessLogic.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UnitOfWork;

namespace BirdCageProduction.Web.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IProgressService _progressService;

        public IndexModel(IOrderService orderService, IProgressService progressService)
        {
            _orderService = orderService;
            _progressService = progressService;
        }

        public IList<BusinessObject.Models.Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Order = (IList<BusinessObject.Models.Order>)await _orderService.GetAllOrderAsync();
                foreach (var order in Order) { 
                    foreach(var orderDetail in order.OrderDetails)
                    {
                        orderDetail.Progresses = await _progressService.GetByOrderDetailId(orderDetail.OrderDetailId);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        //public async Task OnPostToNextProgress(int orderDetailId)
        //{
        //    _orderService.
        //}
    }
}