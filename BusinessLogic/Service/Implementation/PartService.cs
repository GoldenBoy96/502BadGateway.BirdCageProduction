using BusinessLogic.Models.Part;
using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Implementation
{
    public class PartService : IPartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PartService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task AddPart(Part part, string color)
        {
            int colorId = await _unitOfWork.ColorRepository.ReturnIdByName(color);
            part.ColorId = colorId;
            _ = _unitOfWork.PartRepository.Add(part);
            _ = _unitOfWork.Save();
        }

        public async Task<PartOptions> GetPartOptions()
        {
            var response = _configuration.GetSection("PartOptions").Get<PartOptions>();
            return response;
        }

        public async Task<IEnumerable<Part>> GetParts()
        {
            return await _unitOfWork.PartRepository.GetAll();
        }
    }
}
