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

        

        public ICustomerRepository CustomerRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public IBirdCageRepository BirdCageCategoryRepository {  get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public IOrderRepository OrderRepository {  get; }

        public IPartItemRepository PartItemRepository {  get; }

        public IPartRepository PartRepository {  get; }

        public IProcedureRepository ProcedureRepository {  get; }

        public IProcedureStepRepository ProcedureStepRepository {  get; }

        public IAccountStatusRepository AccountStatusRepository { get; }
        public ICustomerStatusRepository CustomerStatusRepository { get; }
        public IOrderStatusRepository OrderStatusRepository { get; }
        public IProgressStatusRepository ProgressStatusRepository { get; }

        public UnitOfWork(BirdCageProductionContext context, ICustomerRepository customerRepository, IAccountRepository accountRepository, ICustomerStatusRepository customerStatusRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
            AccountRepository = accountRepository;
            CustomerStatusRepository = customerStatusRepository;
        }

        //public UnitOfWork(BirdCageProductionContext context, ICustomerRepository customerRepository, IAccountRepository accountRepository, IBirdCageRepository birdCageCategoryRepository, IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IPartItemRepository partItemRepository, IPartRepository partRepository, IProcedureRepository procedureRepository, IProcedureStepRepository procedureStepRepository, IAccountStatusRepository accountStatusRepository, ICustomerStatusRepository customerStatusRepository, IOrderStatusRepository orderStatusRepository, IProgressStatusRepository progressStatusRepository)
        //{
        //    _context = context;
        //    CustomerRepository = customerRepository;
        //    AccountRepository = accountRepository;
        //    BirdCageCategoryRepository = birdCageCategoryRepository;
        //    OrderDetailRepository = orderDetailRepository;
        //    OrderRepository = orderRepository;
        //    PartItemRepository = partItemRepository;
        //    PartRepository = partRepository;
        //    ProcedureRepository = procedureRepository;
        //    ProcedureStepRepository = procedureStepRepository;
        //    AccountStatusRepository = accountStatusRepository;
        //    CustomerStatusRepository = customerStatusRepository;
        //    OrderStatusRepository = orderStatusRepository;
        //    ProgressStatusRepository = progressStatusRepository;
        //}

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
