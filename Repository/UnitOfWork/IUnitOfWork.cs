using DataAccess;
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
        IAccountStatusRepository AccountStatusRepository { get; }
        IBirdCageRepository BirdCageRepository { get; }
        IColorRepository ColorRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICustomerStatusRepository CustomerStatusRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderStatusRepository OrderStatusRepository { get; }
        IPartItemRepository PartItemRepository { get; }
        IPartRepository PartRepository { get; }
        IProcedureRepository ProcedureRepository { get; }
        IProcedureStepRepository ProcedureStepRepository { get; }
        IProgressRepository ProgressRepository { get; }
        IProgressStatusRepository ProgressStatusRepository { get; }
        IRoleRepository RoleRepository { get; }
        Task Save();
    }
}
