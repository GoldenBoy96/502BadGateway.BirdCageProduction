using AutoMapper;
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

        private readonly IMapper _mapper;
        public OrderDetailController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderDetailReponse>>> GetOrderDetails()
        {
            var response = new DataReponse<List<OrderDetailReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get Order Detail success!";
                response.Data = _mapper.Map<List<OrderDetailReponse>>(await _orderService.GetAllOrderDetailAsync());
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
        public async Task<ActionResult<OrderDetailReponse>> GetOrderDetailsById(int id)
        {
            var response = new DataReponse<OrderDetailReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get Order Detail success!";
                response.Data = _mapper.Map<OrderDetailReponse>(await _orderService.GetOrderDetailByIdAsync(id));
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
        public async Task<ActionResult<bool>> AddOrderDetail(OrderDetailReponse orderDetailReponse)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Add Order Detail success!";
                response.Data = await _orderService.AddOrderDetailAsync(_mapper.Map<OrderDetail>(orderDetailReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Order Detail error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateOrderDetail(OrderDetail orderDetail)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Update Order Detail success!";
                response.Data = await _orderService.UpdateOrderDetailAsync(_mapper.Map<OrderDetail>(orderDetail));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Order Detail error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }
    }
}
