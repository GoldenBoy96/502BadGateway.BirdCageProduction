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
        private readonly BirdCageProductionContext _context;

        public UnitOfWork(BirdCageProductionContext context, ICustomerRepository customerRepository, IAccountRepository accountRepository, IBirdCageCategoryRepository birdCageCategoryRepository,
            IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IPartItemRepository partItemRepository, IPartRepository partRepository,
            IProcedureRepository procedureRepository, IProcedureStepRepository procedureStepRepository, IProductionPlanRepository productionPlanRepository,
            IProductionPlanStepRepository productionPlanStepRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
            AccountRepository = accountRepository;
            BirdCageCategoryRepository = birdCageCategoryRepository;
            OrderDetailRepository = orderDetailRepository;
            OrderRepository = orderRepository;
            PartItemRepository = partItemRepository;
            PartRepository = partRepository;
            ProcedureRepository = procedureRepository;
            ProcedureStepRepository = procedureStepRepository;
            ProductionPlanRepository = productionPlanRepository;
            ProductionPlanStepRepository = productionPlanStepRepository;
        }

        public ICustomerRepository CustomerRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public IBirdCageCategoryRepository BirdCageCategoryRepository {  get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public IOrderRepository OrderRepository {  get; }

        public IPartItemRepository PartItemRepository {  get; }

        public IPartRepository PartRepository {  get; }

        public IProcedureRepository ProcedureRepository {  get; }

        public IProcedureStepRepository ProcedureStepRepository {  get; }

        public IProductionPlanRepository ProductionPlanRepository {  get; }

        public IProductionPlanStepRepository ProductionPlanStepRepository {  get; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
