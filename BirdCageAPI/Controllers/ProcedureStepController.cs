using AutoMapper;
using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureStepController : ControllerBase
    {
        private IProcedureService _customerService;
        private readonly IMapper _mapper;
        public ProcedureStepController(IProcedureService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProcedureStepReponse>>> GetProcedureSteps()
        {
            var response = new DataReponse<List<ProcedureStepReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get ProcedureStep success!";
                response.Data = _mapper.Map<List<ProcedureStepReponse>>(await _customerService.GetAllProcedureStepAsync());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get ProcedureSteps error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedureStepReponse>> GetProcedureStepsById(int id)
        {
            var response = new DataReponse<ProcedureStepReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get ProcedureStep success!";
                response.Data = _mapper.Map<ProcedureStepReponse>(await _customerService.GetProcedureStepByIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get ProcedureStep error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProcedureStep(ProcedureStepReponse customerReponse)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Add ProcedureStep success!";
                response.Data = await _customerService.AddProcedureStepAsync(_mapper.Map<ProcedureStep>(customerReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add ProcedureStep error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProcedureStep(ProcedureStepReponse customer)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Update ProcedureStep success!";
                response.Data = await _customerService.UpdateProcedureStepAsync(_mapper.Map<ProcedureStep>(customer));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update ProcedureStep error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

    }
}
