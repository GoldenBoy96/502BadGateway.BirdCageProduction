using DataAccess;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BirdCageProductionContext _context;

        public UnitOfWork(BirdCageProductionContext context, IAccountRepository accountRepository, IAccountStatusRepository accountStatusRepository, IBirdCageRepository birdCageRepository, IColorRepository colorRepository, ICustomerRepository customerRepository, ICustomerStatusRepository customerStatusRepository, IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IOrderStatusRepository orderStatusRepository, IPartItemRepository partItemRepository, IPartRepository partRepository, IProcedureRepository procedureRepository, IProcedureStepRepository procedureStepRepository, IProgressRepository progressRepository, IProgressStatusRepository progressStatusRepository, IRoleRepository roleRepository)
        {
            _context = context;
            AccountRepository = accountRepository;
            AccountStatusRepository = accountStatusRepository;
            BirdCageRepository = birdCageRepository;
            ColorRepository = colorRepository;
            CustomerRepository = customerRepository;
            CustomerStatusRepository = customerStatusRepository;
            OrderDetailRepository = orderDetailRepository;
            OrderRepository = orderRepository;
            OrderStatusRepository = orderStatusRepository;
            PartItemRepository = partItemRepository;
            PartRepository = partRepository;
            ProcedureRepository = procedureRepository;
            ProcedureStepRepository = procedureStepRepository;
            ProgressRepository = progressRepository;
            ProgressStatusRepository = progressStatusRepository;
            RoleRepository = roleRepository;
        }

        public IAccountRepository AccountRepository { get; }

        public IAccountStatusRepository AccountStatusRepository { get; }

        public IBirdCageRepository BirdCageRepository { get; }

        public IColorRepository ColorRepository { get; }

        public ICustomerRepository CustomerRepository { get; }

        public ICustomerStatusRepository CustomerStatusRepository { get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IOrderStatusRepository OrderStatusRepository { get; }

        public IPartItemRepository PartItemRepository { get; }

        public IPartRepository PartRepository { get; }

        public IProcedureRepository ProcedureRepository { get; }

        public IProcedureStepRepository ProcedureStepRepository { get; }

        public IProgressRepository ProgressRepository { get; }

        public IProgressStatusRepository ProgressStatusRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
