using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Implementation
{
    public class ProcedureService : IProcedureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcedureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddProcedureAsync(Procedure procedure)
        {
            return await _unitOfWork.ProcedureRepository.AddAsync(procedure);
        }

        public async Task<bool> AddProcedureStepAsync(ProcedureStep procedureStep)
        {
            return await _unitOfWork.ProcedureStepRepository.AddAsync(procedureStep);
        }

        public async Task<bool> DeleteProcedureAsync(Procedure procedure)
        {
            return await _unitOfWork.ProcedureRepository.RemoveAsync(procedure);
        }

        public async Task<bool> DeleteProcedureAsync(int procedureId)
        {
            var entity = await _unitOfWork.ProcedureRepository.GetById(procedureId);
            return await _unitOfWork.ProcedureRepository.RemoveAsync(entity);
        }

        public async Task<bool> DeleteProcedureStepAsync(ProcedureStep procedureStep)
        {
            return await _unitOfWork.ProcedureStepRepository.RemoveAsync(procedureStep);
        }

        public async Task<IEnumerable<Procedure>> GetAllProcedureAsync()
        {
            return await _unitOfWork.ProcedureRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ProcedureStep>> GetAllProcedureStepAsync()
        {
            return await _unitOfWork.ProcedureStepRepository.GetAllAsync();
        }

        public async Task<Procedure?> GetProcedureByIdAsync(int procedureId)
        {
            return await _unitOfWork.ProcedureRepository.GetById(procedureId);
        }

        public async Task<ProcedureStep?> GetProcedureStepByIdAsync(int procedureStepId)
        {
            return await _unitOfWork.ProcedureStepRepository.GetById(procedureStepId);
        }

        public async Task<bool> UpdateProcedureAsync(Procedure procedure)
        {
            return await _unitOfWork.ProcedureRepository.UpdateAsync(procedure);
        }

        public async Task<bool> UpdateProcedureStepAsync(ProcedureStep procedureStep)
        {
            return await _unitOfWork.ProcedureStepRepository.UpdateAsync(procedureStep);
        }
    }
}
