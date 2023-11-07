using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Models.Reponse;
using AutoMapper;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderReponse>>> GetOrders()
        {
            var response = new DataReponse<List<OrderReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get Order success!";
                response.Data = _mapper.Map<List<OrderReponse>>((List<Order>?)await _orderService.GetAllOrderAsync());
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
        public async Task<ActionResult<OrderReponse>> GetOrdersById(int id)
        {
            var response = new DataReponse<OrderReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get Order success!";
                response.Data = _mapper.Map<OrderReponse>(await _orderService.GetOrderByIdAsync(id));
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
        public async Task<ActionResult<bool>> AddOrder(OrderReponse orderReponse)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Add Order success!";
                response.Data = await _orderService.AddOrderAsync(_mapper.Map<Order>(orderReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Order error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateOrder(OrderReponse orderReponse)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Update Order success!";
                response.Data = await _orderService.UpdateOrderAsync(_mapper.Map<Order>(orderReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Order error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }


    }
}
