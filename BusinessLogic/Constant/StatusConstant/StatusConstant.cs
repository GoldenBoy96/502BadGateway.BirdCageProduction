using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Repository.IRepositories;
using Repository.Repositories;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Constant.StatusConstant
{
    public class StatusConstant : IStatusConstant
    {

        private readonly DataAccess.BirdCageProductionContext _context;
        IUnitOfWork _unitOfWork;

        IAccountStatusRepository _accountStatusRepository;
        CustomerStatusRepository _customerStatusRepository;
        OrderStatusRepository _orderStatusRepository;
        ProgressStatusRepository _progressStatusRepository;

        List<AccountStatus> _accountStatusList = new();
        List<string> _customerStatusList = new();
        List<string> _orderStatusList = new();
        List<string> _progressStatusList = new();


        public StatusConstant(IUnitOfWork unitOfWork, IAccountStatusRepository accountStatusRepository, CustomerStatusRepository customerStatusRepository, OrderStatusRepository orderStatusRepository, ProgressStatusRepository progressStatusRepository)
        {
            _unitOfWork = unitOfWork;
            _accountStatusRepository = accountStatusRepository;
            _customerStatusRepository = customerStatusRepository;
            _orderStatusRepository = orderStatusRepository;
            _progressStatusRepository = progressStatusRepository;

            _accountStatusList = _accountStatusRepository.GetAll().ToList();


            
        }


        public void PrintAccountStatus()
        {
            foreach (var accountStatus in _accountStatusList)
            {
                System.Diagnostics.Debug.WriteLine("================" + accountStatus.Name);
            }
        }

        
    }
}
