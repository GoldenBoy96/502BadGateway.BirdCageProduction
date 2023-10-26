using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account?> GetByEmail(string email);
        Task<Account?> LoginAsync(string email, string password);

        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<int> CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
    }
}
