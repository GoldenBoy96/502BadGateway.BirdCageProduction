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

        public UnitOfWork(BirdCageProductionContext context, ICustomerRepository customerRepository, IAccountRepository accountRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
            AccountRepository = accountRepository;
        }

        public ICustomerRepository CustomerRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public IBirdCageRepository BirdCageCategoryRepository {  get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public IOrderRepository OrderRepository {  get; }

        public IPartItemRepository PartItemRepository {  get; }

        public IPartRepository PartRepository {  get; }

        public IProcedureRepository ProcedureRepository {  get; }

        public IProcedureStepRepository ProcedureStepRepository {  get; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
