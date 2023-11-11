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
                Order = (IList<BusinessObject.Models.Order>) _orderService.GetAllOrderAsync().Result;
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

        public async Task<IActionResult> OnPostToNextProgress(int id)
        {
            try
            {
                Order = (IList<BusinessObject.Models.Order>)_orderService.GetAllOrderAsync().Result;
                foreach (var order in Order)
                {
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        orderDetail.Progresses = await _progressService.GetByOrderDetailId(orderDetail.OrderDetailId);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            System.Diagnostics.Debug.WriteLine(id + "OnPostToNextProgress ==============================");
            return Page();
        }

        public async Task<IActionResult> OnPostGenerateProgress(int id)
        {
            _progressService.GenerateProgressFromProcedure(await _orderService.GetOrderDetailByIdAsync(id));
            try
            {
                Order = (IList<BusinessObject.Models.Order>)_orderService.GetAllOrderAsync().Result;
                foreach (var order in Order)
                {
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        orderDetail.Progresses = await _progressService.GetByOrderDetailId(orderDetail.OrderDetailId);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            

            System.Diagnostics.Debug.WriteLine(id + "OnPostGenerateProgress ======================================================================================");
            return Page();

        }public async Task<IActionResult> OnPostToNextStatus(int id)
        {
            
            try
            {
                Order = (IList<BusinessObject.Models.Order>)_orderService.GetAllOrderAsync().Result;
                foreach (var order1 in Order)
                {
                    foreach (var orderDetail in order1.OrderDetails)
                    {
                        orderDetail.Progresses = await _progressService.GetByOrderDetailId(orderDetail.OrderDetailId);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            //BusinessObject.Models.Order order = _orderService.GetOrderByIdAsync(orderId).Result;
            await _orderService.MoveToNextStatus(id);
            

            return Page();

        }
    }
}