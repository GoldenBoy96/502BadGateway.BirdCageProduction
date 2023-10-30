using BusinessObject.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        //private readonly BirdCageProductionContext _context;

        public AccountRepository(BirdCageProductionContext context) : base(context)
        {
            //_context = context;
        }

        public Task<Account?> GetByEmail(string email)
        {
            return _context.Accounts.FirstOrDefaultAsync(acc => acc.Email.Equals(email));
        }

        // Check login by email & password
        public Task<Account?> LoginAsync(string email, string password)
        {
            var x = _context.Accounts.FirstOrDefaultAsync(acc => (acc.Email.Equals(email) && acc.Password.Equals(password)));
            return x;
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _context.Accounts.FindAsync(accountId);
        }

        public async Task<int> CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account.AccountId;
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var account = await _context.Accounts.FindAsync(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
