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
            Procedure procedure = unitOfWork.ProcedureRepository.GetByBirdCageId(birdCage.BirdCageId);
            List<Progress> progressList = new List<Progress>();
            if (procedure != null)
            {
                List<ProcedureStep> procedureSteps = unitOfWork.ProcedureStepRepository.GetByProcedureId(procedure.ProcedureId).Result;

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
                        progress.StartDay = progressList.LastOrDefault().EndDay.Value.AddDays(1);
                        progress.StatusId = 0;
                    }
                    progress.EndDay = progress.StartDay.Value.AddDays((int)procedureSteps[i].TimeNeeded);
                    progressList.Add(progress);

                    progress.AccountId = order.AccountId;
                    progress.OrderDetailId = orderDetail.OrderDetailId;
                    await unitOfWork.ProgressRepository.AddAsync(progress);
                }
            }

            return progressList;
        }

        public async Task MoveToNextProgress(OrderDetail orderDetail)
        {
            List<Progress> progresses = unitOfWork.ProgressRepository.GetByOrderDetailId(orderDetail.OrderDetailId).OrderBy(c => c.ProgressNum).ToList();
            if (orderDetail.CurrentStep == progresses.Count - 1)
            {
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

        public async Task<double?> CalculateCostOfAnOrder(Order order)
        {
            double? cost = 0;
            foreach (OrderDetail orderDetail in order.OrderDetails)
            {
                BirdCage birdCage = unitOfWork.BirdCageRepository.GetById(orderDetail.BirdCageId).Result;
                List<PartItem> parts = unitOfWork.PartItemRepository.GetByBirdCageId((int)orderDetail.BirdCageId);
                Procedure procedure = unitOfWork.ProcedureRepository.GetByBirdCageId(birdCage.BirdCageId);
                List<ProcedureStep> procedureSteps = unitOfWork.ProcedureStepRepository.GetByProcedureId(procedure.ProcedureId).Result;
                double? materialCost = 0;
                double? procedureCost = 0;
                foreach(PartItem partItem in parts)
                {
                    try
                    {
                        materialCost += partItem.Part.Cost * partItem.Quantity;
                    }
                    catch (Exception ex) { }
                }
                foreach (ProcedureStep step in procedureSteps)
                {
                    try
                    {
                        procedureCost += step.Cost;
                    }
                    catch (Exception ex) { }
                }
                cost += materialCost + procedureCost;
            }
            order.TotalPrice = (decimal?)cost;
            await unitOfWork.OrderRepository.UpdateAsync(order);
            return cost;
        }

        public async Task<List<Progress>> StartProduction(OrderDetail orderDetail)
        {
            BirdCage birdCage = unitOfWork.BirdCageRepository.GetById(orderDetail.BirdCageId).Result;
            Order order = unitOfWork.OrderRepository.GetById(orderDetail.OrderId).Result;
            Procedure procedure = unitOfWork.ProcedureRepository.GetByBirdCageId(birdCage.BirdCageId);
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
                }
                else
                {
                    progress.StartDay = progressList.LastOrDefault().EndDay.Value.AddDays(1);
                    progress.StatusId = 0;
                }
                progress.EndDay = progress.StartDay.Value.AddDays((int)procedureSteps[i].TimeNeeded);


                progress.AccountId = order.AccountId;
                progress.OrderDetailId = orderDetail.OrderDetailId;
                await unitOfWork.ProgressRepository.UpdateAsync(progress);
            }
            return progressList;
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
