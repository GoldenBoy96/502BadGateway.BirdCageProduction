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

        AccountStatusRepository _accountStatusRepository;
        //CustomerStatusRepository _customerStatusRepository;
        //OrderStatusRepository _orderStatusRepository;
        //ProgressStatusRepository _progressStatusRepository;

        List<AccountStatus> _accountStatusList = new();
        List<string> _customerStatusList = new();
        List<string> _orderStatusList = new();
        List<string> _progressStatusList = new();


        //private static StatusConstant? _instance;

        //public static StatusConstant Instance
        //{
        //    get
        //    {
        //        _instance ??= new StatusConstant();
        //        return _instance;
        //    }
        //}

        public StatusConstant(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            //_accountStatusRepository = new(_context);
            //_accountStatusList = GetAllAccountStatusAsync().Result;
            //System.Diagnostics.Debug.WriteLine("================" + _accountStatusList[0].Name);
            
            _accountStatusList = _unitOfWork.AccountStatusRepository.GetAllAsync().Result.ToList(); 
            
        }

        public async Task<List<AccountStatus>> GetAllAccountStatusAsync()
        {
            //_accountStatusList = (List<AccountStatus>)await _unitOfWork.AccountStatusRepository.GetAll();
            return (List<AccountStatus>)await _accountStatusRepository.GetAllAsync();
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
