using AutoMapper;
using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private IProcedureService _procedureService;
        private readonly IMapper _mapper;
        public ProcedureController(IProcedureService procedureService, IMapper mapper)
        {
            _procedureService = procedureService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProcedureReponse>>> GetProcedures()
        {
            var response = new DataReponse<List<ProcedureReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get Procedure success!";
                response.Data = _mapper.Map<List<ProcedureReponse>>(await _procedureService.GetAllProcedureAsync());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Procedures error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedureReponse>> GetProceduresById(int id)
        {
            var response = new DataReponse<ProcedureReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get Procedure success!";
                response.Data = _mapper.Map<ProcedureReponse>(await _procedureService.GetProcedureByIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Procedure error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProcedure(ProcedureReponse procedureReponse)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Add Procedure success!";
                response.Data = await _procedureService.AddProcedureAsync(_mapper.Map<Procedure>(procedureReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Procedure error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProcedure(ProcedureReponse procedure)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Update Procedure success!";
                response.Data = await _procedureService.UpdateProcedureAsync(_mapper.Map<Procedure>(procedure));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Procedure error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

    }
}
