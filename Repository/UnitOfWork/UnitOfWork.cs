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

        public UnitOfWork(BirdCageProductionContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
        }

        public ICustomerRepository CustomerRepository { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
