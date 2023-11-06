using AutoMapper;
using BusinessLogic.Models.Reponse;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdCageController : ControllerBase
    {
        private IBirdCageService _customerService;
        private readonly IMapper _mapper;
        public BirdCageController(IBirdCageService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<BirdCageReponse>>> GetBirdCages()
        {
            var response = new DataReponse<List<BirdCageReponse>>();
            try
            {
                response.Success = true;
                response.Message = "Get BirdCage success!";
                response.Data = _mapper.Map<List<BirdCageReponse>>(await _customerService.GetBirdCages());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get BirdCages error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BirdCageReponse>> GetBirdCagesById(int id)
        {
            var response = new DataReponse<BirdCageReponse>();
            try
            {
                response.Success = true;
                response.Message = "Get BirdCage success!";
                response.Data = _mapper.Map<BirdCageReponse>(await _customerService.GetBirdCageById(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Get BirdCage error!";
                response.Data = null;
                return NotFound(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<bool>> AddBirdCage(BirdCageReponse customerReponse)
        //{
        //    var response = new DataReponse<bool>();
        //    try
        //    {
        //        response.Success = true;
        //        response.Message = "Add BirdCage success!";
        //        response.Data = await _customerService.EditBirtCage(_mapper.Map<BirdCage>(customerReponse));
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Add BirdCage error!";
        //        response.Data = false;
        //        return NotFound(ex.Message);
        //    }
        //}

        //[HttpPut]
        //public async Task<ActionResult<bool>> UpdateBirdCage(BirdCageReponse customer)
        //{
        //    var response = new DataReponse<bool>();
        //    try
        //    {
        //        response.Success = true;
        //        response.Message = "Update BirdCage success!";
        //        response.Data = await _customerService.EditBirtCage(_mapper.Map<BirdCage>(customer));
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Update BirdCage error!";
        //        response.Data = false;
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
