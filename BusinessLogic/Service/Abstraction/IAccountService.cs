using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<int> CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
    }
}
