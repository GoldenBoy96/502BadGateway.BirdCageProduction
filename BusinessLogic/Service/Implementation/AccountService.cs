using BusinessLogic.Service.Abstraction;
using BusinessObject.Models;
using Repository.IRepositories;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _unitOfWork.AccountRepository.GetAllAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int? accountId)
        {
            return await _unitOfWork.AccountRepository.GetById(accountId);
        }

        public async Task<bool> CreateAccountAsync(Account account)
        {
            return await _unitOfWork.AccountRepository.AddAsync(account);
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            return await  _unitOfWork.AccountRepository.UpdateAsync(account);
        }

        public async Task<bool> DeleteAccountAsync(Account account)
        {
            return await _unitOfWork.AccountRepository.RemoveAsync(account);
        }
    }

}
