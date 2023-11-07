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
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerReponse>>> GetCustomers()
        {
            var response = new DataReponse<List<CustomerReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get Customer success!";
                response.Data = _mapper.Map<List<CustomerReponse>>(await _customerService.GetAllCustomerAsync()) ;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Customers error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReponse>> GetCustomersById(int id)
        {
            var response = new DataReponse<CustomerReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get Customer success!";
                response.Data = _mapper.Map<CustomerReponse>(await _customerService.GetCustomerByIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Customer error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddCustomer(CustomerReponse customerReponse)
        {
            var response = new DataReponse<bool>();
            try
            {  
                response.Success = true;
                response.Message = "Add Customer success!";
                response.Data = await _customerService.AddCustomerAsync(_mapper.Map<Customer>(customerReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Customer error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCustomer(CustomerReponse customer)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Update Customer success!";
                response.Data = await _customerService.UpdateCustomerAsync(_mapper.Map<Customer>(customer));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Customer error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

    }
}
