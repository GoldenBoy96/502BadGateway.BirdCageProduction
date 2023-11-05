using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Models.Reponse;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var response = new DataReponse<List<Order>>();
            try
            {
                response.Success = true;
                response.Message = "Get Order success!";
                response.Data = await _orderService.GetAllOrderAsync();                
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Orders error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Order>>> GetOrdersById(int id)
        {
            var response = new DataReponse<List<Order>>();
            try
            {
                response.Success = true;
                response.Message = "Get Order success!";
                response.Data = await _orderService.GetOrderByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Order error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(Order order)
        {
            var response = new DataReponse<List<Order>>();
            try
            {
                response.Success = true;
                response.Message = "Add Order success!";
                response.Data = await _orderService.AddOrderAsync(order);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Order error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order order)
        {
            var response = new DataReponse<List<Order>>();
            try
            {
                response.Success = true;
                response.Message = "Update Order success!";
                response.Data = await _orderService.UpdateOrderAsync(order);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Order error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        
    }
}
