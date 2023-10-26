using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _repository.GetAllAccountsAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _repository.GetAccountByIdAsync(accountId);
        }

        public async Task<int> CreateAccountAsync(Account account)
        {
            return await _repository.CreateAccountAsync(account);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _repository.UpdateAccountAsync(account);
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            await _repository.DeleteAccountAsync(accountId);
        }
    }

}
