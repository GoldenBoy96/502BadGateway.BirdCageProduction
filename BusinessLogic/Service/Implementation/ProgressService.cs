using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Microsoft.IdentityModel.Tokens;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Implementation
{
    public class ProgressService : IProgressService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProgressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Progress>> GetByOrderDetailId(int orderDetailId)
        {
            return unitOfWork.ProgressRepository.GetByOrderDetailId(orderDetailId);
        }

        public async Task<List<Progress>> GenerateProgressFromProcedure(OrderDetail orderDetail)
        {
            List<Progress> oldProgresses = unitOfWork.ProgressRepository.GetByOrderDetailId(orderDetail.OrderDetailId);
            if (!oldProgresses.IsNullOrEmpty()) { return oldProgresses; }


            BirdCage birdCage = unitOfWork.BirdCageRepository.GetById(orderDetail.BirdCageId).Result;
            Order order = unitOfWork.OrderRepository.GetById(orderDetail.OrderId).Result;
            Procedure procedure = unitOfWork.ProcedureRepository.GetByBirdCageId(birdCage.BirdCageId).Result;
            List<ProcedureStep> procedureSteps = unitOfWork.ProcedureStepRepository.GetByProcedureId(procedure.ProcedureId).Result;
            List<Progress> progressList = new List<Progress>();
            for (int i = 0; i < procedureSteps.Count; i++)
            {
                Progress progress = new Progress();
                progress.ProgressNum = i;
                if (i == 0)
                {
                    progress.StartDay = DateTime.Now;
                    progress.StatusId = 1;
                    orderDetail.CurrentStep = 0;
                    await unitOfWork.OrderDetailRepository.UpdateAsync(orderDetail);
                }
                else
                {
                    progress.StartDay = progressList[i - 1].EndDay.Value.AddDays(1);
                    progress.StatusId = 0;
                }
                progress.EndDay = progress.StartDay.Value.AddDays((int)procedureSteps[i].TimeNeeded);


                progress.AccountId = order.AccountId;
                progress.OrderDetailId = orderDetail.OrderDetailId;
                await unitOfWork.ProgressRepository.AddAsync(progress);
            }
            return progressList;
        }

        public async Task MoveToNextProgress(OrderDetail orderDetail)
        {
            List<Progress> progresses = (List<Progress>)unitOfWork.ProgressRepository.GetByOrderDetailId(orderDetail.OrderDetailId).OrderBy(c => c.ProgressNum);
            if (orderDetail.CurrentStep == progresses.Count - 1)
            {
                orderDetail.CurrentStep = 2;
                await unitOfWork.OrderDetailRepository.UpdateAsync(orderDetail);
                progresses[progresses.Count - 1].StatusId = 2;
                await unitOfWork.ProgressRepository.UpdateAsync(progresses[progresses.Count - 1]);
            }
            else if (orderDetail.CurrentStep < progresses.Count - 1)
            {
                progresses[(int)orderDetail.CurrentStep].StatusId = 2;
                await unitOfWork.ProgressRepository.UpdateAsync(progresses[(int)orderDetail.CurrentStep]);
                orderDetail.CurrentStep++;
                await unitOfWork.OrderDetailRepository.UpdateAsync(orderDetail);
                progresses[(int)orderDetail.CurrentStep].StatusId = 1;
                await unitOfWork.ProgressRepository.UpdateAsync(progresses[(int)orderDetail.CurrentStep]);

            }

        }

        public Task<bool> AddProgressAsync(Progress order)
        {
            return unitOfWork.ProgressRepository.AddAsync(order);
        }

        public Task<bool> DeleteProgressAsync(Progress order)
        {
            return unitOfWork.ProgressRepository.RemoveAsync(order);
        }

        public Task<IEnumerable<Progress>> GetAllProgressAsync()
        {
            return unitOfWork.ProgressRepository.GetAllAsync();
        }

        public Task<Progress?> GetProgressByIdAsync(int ProgressId)
        {
            return unitOfWork.ProgressRepository.GetById(ProgressId);
        }

        public Task<bool> UpdateProgressAsync(Progress order)
        {
            return unitOfWork.ProgressRepository.UpdateAsync(order);
        }


    }
}
