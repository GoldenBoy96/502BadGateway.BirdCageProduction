using AutoMapper;
using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private IAccountService _customerService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<AccountReponse>>> GetAccounts()
        {
            var response = new DataReponse<List<AccountReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get Account success!";
                response.Data = _mapper.Map<List<AccountReponse>>(await _customerService.GetAllAccountsAsync());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Accounts error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountReponse>> GetAccountsById(int id)
        {
            var response = new DataReponse<AccountReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get Account success!";
                response.Data = _mapper.Map<AccountReponse>(await _customerService.GetAccountByIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Account error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddAccount(AccountReponse customerReponse)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Add Account success!";
                response.Data = await _customerService.CreateAccountAsync(_mapper.Map<Account>(customerReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Account error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAccount(AccountReponse customer)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Update Account success!";
                response.Data = await _customerService.UpdateAccountAsync(_mapper.Map<Account>(customer));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Account error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }
    }
}
