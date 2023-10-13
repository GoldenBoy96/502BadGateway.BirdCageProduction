using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IBirdCageCategoryRepository BirdCageCategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPartItemRepository PartItemRepository { get; }
        IPartRepository PartRepository { get; }
        IProcedureRepository ProcedureRepository { get; }
        IProcedureStepRepository ProcedureStepRepository { get; }
        IProductionPlanRepository ProductionPlanRepository { get; }
        IProductionPlanStepRepository ProductionPlanStepRepository { get; }
        Task Save();
    }
}
