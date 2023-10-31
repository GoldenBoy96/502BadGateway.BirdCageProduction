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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            part.Code = model.Code;
            part.Description = model.Description;
            part.Shape = model.Shape;
            part.Material = model.Material;
            part.Size = model.Size;
            part.ColorId = await _unitOfWork.ColorRepository.ReturnIdByName(model.ColorName);
            part.Cost = model.Cost;
            
            
            _unitOfWork.PartRepository.AddAsync(part);
        }

        public async Task<bool> DeletePart(int id)
        {
            try
            {
                var part = await _unitOfWork.PartRepository.GetByIdAsync(id);
                await _unitOfWork.PartRepository.RemoveAsync(part);
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task EditPart(PartPageModel model)
        {
            var part = new Part
            {
                PartId = model.PartId,
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
                Shape = model.Shape,
                Material = model.Material,
                Size = model.Size,
                ColorId = await _unitOfWork.ColorRepository.ReturnIdByName(model.ColorName),
                Cost = model.Cost
            };

            _unitOfWork.PartRepository.UpdateAsync(part);
        }

        public async Task<PartPageModel> GetPartById(int id)
        {
            var data = await _unitOfWork.PartRepository.GetByIdAsync(id);
            var respone = new PartPageModel
            {
                PartId = id,
                Name = data.Name,
                Code = data.Code,
                Description = data.Description,
                Shape = data.Shape,
                Material = data.Material,
                ColorName = (await _unitOfWork.ColorRepository.GetAllAsync()).FirstOrDefault(c => c.ColorId == data.ColorId).ColorName,
                Cost = data.Cost,
            };

            return respone;
        }

        public async Task<PartOptions> GetPartOptions()
        {
            var response = _configuration.GetSection("PartOptions").Get<PartOptions>();
            return response;
        }

        public async Task<IEnumerable<PartPageModel>> GetParts()
        {
            var parts = await _unitOfWork.PartRepository.GetAllAsync();
            var response = new List<PartPageModel>();
            foreach (var part in parts) 
            {
                response.Add(new PartPageModel
                {
                    PartId = part.PartId,
                    Name = part.Name,
                    Code = part.Code,
                    Description = part.Description,
                    Shape = part.Shape,
                    Material = part.Material,
                    ColorName = (await _unitOfWork.ColorRepository.GetAllAsync()).FirstOrDefault(c => c.ColorId == part.ColorId).ColorName,
                    Cost = part.Cost,
                });
            }
            return response;
        }

        public Task<IEnumerable<string?>> PartCodes()
        {
            return _unitOfWork.PartRepository.GetPartCodes();
        }
    }
}
