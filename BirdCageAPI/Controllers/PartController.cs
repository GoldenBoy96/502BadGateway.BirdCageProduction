using AutoMapper;
using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        

        private IPartService _partService;
        private readonly IMapper _mapper;
        public PartController(IPartService partService, IMapper mapper)
        {
            _partService = partService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<PartReponse>>> GetParts()
        {
            var response = new DataReponse<List<PartReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get Part success!";
                response.Data = _mapper.Map<List<PartReponse>>(await _partService.GetParts());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Parts error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartReponse>> GetPartsById(int id)
        {
            var response = new DataReponse<PartReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get Part success!";
                response.Data = _mapper.Map<PartReponse>(await _partService.GetPartById(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get Part error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<bool>> AddPart(PartReponse partReponse)
        //{
        //    var response = new DataReponse<bool>();
        //    try
        //    {
        //        response.Success = true;
        //        response.Message = "Add Part success!";
        //        response.Data = await _partService.AddPart(_mapper.Map<Part>(partReponse));
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Add Part error!";
        //        response.Data = false;
        //        return NotFound(ex.Message);
        //    }
        //}

        //[HttpPut]
        //public async Task<ActionResult<bool>> UpdatePart(PartReponse part)
        //{
        //    var response = new DataReponse<bool>();
        //    try
        //    {
        //        response.Success = true;
        //        response.Message = "Update Part success!";
        //        response.Data = await _partService.UpdatePartAsync(_mapper.Map<Part>(part));
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Update Part error!";
        //        response.Data = false;
        //        return NotFound(ex.Message);
        //    }
        //}

    }

}
