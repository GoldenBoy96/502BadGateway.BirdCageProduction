using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderDetailController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderDetail>>> GetOrderDetails()
        {
            var response = new DataReponse<List<OrderDetail>>();
            try
            {
                response.Success = true;
                response.Message = "Get Order Detail success!";
                response.Data = await _orderService.GetAllOrderDetailAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get OrderDetails error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrderDetail>>> GetOrderDetailsById(int id)
        {
            var response = new DataReponse<List<OrderDetail>>();
            try
            {
                response.Success = true;
                response.Message = "Get Order Detail success!";
                response.Data = await _orderService.GetOrderDetailByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Order Detail error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderDetail>>> AddOrderDetail(OrderDetail orderDetail)
        {
            var response = new DataReponse<List<OrderDetail>>();
            try
            {
                response.Success = true;
                response.Message = "Add Order Detail success!";
                response.Data = await _orderService.AddOrderDetailAsync(orderDetail);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Order Detail error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OrderDetail>>> UpdateOrderDetail(OrderDetail orderDetail)
        {
            var response = new DataReponse<List<OrderDetail>>();
            try
            {
                response.Success = true;
                response.Message = "Update Order Detail success!";
                response.Data = await _orderService.UpdateOrderDetailAsync(orderDetail);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Order Detail error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }
    }
}
