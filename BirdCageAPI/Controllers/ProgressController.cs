using AutoMapper;
using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private IProgressService _progressService;
        private readonly IMapper _mapper;
        public ProgressController(IProgressService progressService, IMapper mapper)
        {
            _progressService = progressService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProgressReponse>>> GetProgresss()
        {
            var response = new DataReponse<List<ProgressReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get Progress success!";
                response.Data = _mapper.Map<List<ProgressReponse>>(await _progressService.GetAllProgressAsync());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Progresss error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgressReponse>> GetProgresssById(int id)
        {
            var response = new DataReponse<ProgressReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get Progress success!";
                response.Data = _mapper.Map<ProgressReponse>(await _progressService.GetProgressByIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Progress error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProgress(ProgressReponse progressReponse)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Add Progress success!";
                response.Data = await _progressService.AddProgressAsync(_mapper.Map<Progress>(progressReponse));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Add Progress error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProgress(ProgressReponse progress)
        {
            var response = new DataReponse<bool>();
            try
            {
                response.Success = true;
                response.Message = "Update Progress success!";
                response.Data = await _progressService.UpdateProgressAsync(_mapper.Map<Progress>(progress));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Update Progress error!";
                response.Data = false;
                return NotFound(ex.Message);
            }
        }

    }
}
