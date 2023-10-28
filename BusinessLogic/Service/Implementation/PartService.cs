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

        public async Task AddPart(PartPageModel model)
        {
            var part = new Part();
            part.Name = model.Name;
            part.Description = model.Description;
            part.Shape = model.Shape;
            part.Size = model.Size;
            part.ColorId = await _unitOfWork.ColorRepository.ReturnIdByName(model.Color);
            part.Cost = model.Cost;
            
            
            _ = _unitOfWork.PartRepository.Add(part);
            _ = _unitOfWork.Save();
        }

        public async Task EditPart(PartPageModel model)
        {
            var data = await _unitOfWork.PartRepository.GetById(model.PartId);
            data.Name = model.Name;
            data.Description = model.Description;
            data.Shape = model.Shape;
            data.Material = model.Material;
            data.Cost = model.Cost;
            data.ColorId = await _unitOfWork.ColorRepository.ReturnIdByName(model.Color);

            
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
