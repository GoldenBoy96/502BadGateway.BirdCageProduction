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

<<<<<<< HEAD
        
=======
        public UnitOfWork(BirdCageProductionContext context, ICustomerRepository customerRepository, IAccountRepository accountRepository,
            IAccountStatusRepository accountStatusRepository, IPartRepository partRepository, IColorRepository colorRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
            AccountRepository = accountRepository;
            AccountStatusRepository = accountStatusRepository;
            PartRepository = partRepository;
            ColorRepository = colorRepository;
        }
>>>>>>> bf440a8fbe0b468e055f82b4bbbdd07eb86a0200

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

<<<<<<< HEAD
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
=======
        public IColorRepository ColorRepository { get; }
>>>>>>> bf440a8fbe0b468e055f82b4bbbdd07eb86a0200

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
