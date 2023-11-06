//using AutoMapper;
//using BusinessLogic.Models.Reponse;
//using BusinessLogic.Service.Abstraction;
//using BusinessObject.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace BirdCageAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PartItemController : ControllerBase
//    {
//        private IPartItemService _partItemService;
//        private readonly IMapper _mapper;
//        public PartItemController(IPartItemService partItemService, IMapper mapper)
//        {
//            _partItemService = partItemService;
//            _mapper = mapper;
//        }
//        [HttpGet]
//        public async Task<ActionResult<List<PartItemReponse>>> GetPartItems()
//        {
//            var response = new DataReponse<List<PartItemReponse>>();
//            try
//            {
//                response.Success = true;
//                response.Message = "Get PartItem success!";
//                response.Data = _mapper.Map<List<PartItemReponse>>(await _partItemService.GetAllPartItemAsync());
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                response.Success = false;
//                response.Message = "Get PartItems error!";
//                response.Data = null;
//                return NotFound(ex.Message);
//            }
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<PartItemReponse>> GetPartItemsById(int id)
//        {
//            var response = new DataReponse<PartItemReponse>();
//            try
//            {
//                response.Success = true;
//                response.Message = "Get PartItem success!";
//                response.Data = _mapper.Map<PartItemReponse>(await _partItemService.GetPartItemByIdAsync(id));
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                response.Success = false;
//                response.Message = "Get PartItem error!";
//                response.Data = null;
//                return NotFound(ex.Message);
//            }
//        }

//        [HttpPost]
//        public async Task<ActionResult<bool>> AddPartItem(PartItemReponse partItemReponse)
//        {
//            var response = new DataReponse<bool>();
//            try
//            {
//                response.Success = true;
//                response.Message = "Add PartItem success!";
//                response.Data = await _partItemService.AddPartItemAsync(_mapper.Map<PartItem>(partItemReponse));
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                response.Success = false;
//                response.Message = "Add PartItem error!";
//                response.Data = false;
//                return NotFound(ex.Message);
//            }
//        }

//        [HttpPut]
//        public async Task<ActionResult<bool>> UpdatePartItem(PartItemReponse partItem)
//        {
//            var response = new DataReponse<bool>();
//            try
//            {
//                response.Success = true;
//                response.Message = "Update PartItem success!";
//                response.Data = await _partItemService.UpdatePartItemAsync(_mapper.Map<PartItem>(partItem));
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                response.Success = false;
//                response.Message = "Update PartItem error!";
//                response.Data = false;
//                return NotFound(ex.Message);
//            }
//        }

//    }
//}
