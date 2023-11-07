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

        IAccountStatusRepository _accountStatusRepository;
        ICustomerStatusRepository _customerStatusRepository;
        IOrderStatusRepository _orderStatusRepository;
        IProgressStatusRepository _progressStatusRepository;

        List<string> _accountStatusList = new();
        List<string> _customerStatusList = new();
        List<string> _orderStatusList = new();
        List<string> _progressStatusList = new();


        public StatusConstant(IAccountStatusRepository accountStatusRepository, ICustomerStatusRepository customerStatusRepository, IOrderStatusRepository orderStatusRepository, IProgressStatusRepository progressStatusRepository)
        {
            _accountStatusRepository = accountStatusRepository;
            _customerStatusRepository = customerStatusRepository;
            _orderStatusRepository = orderStatusRepository;
            _progressStatusRepository = progressStatusRepository;

            foreach (var item in _accountStatusRepository.GetAll())
            {
                if (item == null)
                {
                    _accountStatusList.Add("");
                }
                else
                {
                    _accountStatusList.Add(item.Name);
                }
            }
            foreach (var item in _customerStatusRepository.GetAll())
            {
                if (item == null)
                {
                    _customerStatusList.Add("");
                }
                else
                {
                    _customerStatusList.Add(item.Name);
                }
            }
            foreach (var item in _orderStatusRepository.GetAll())
            {
                if (item == null)
                {
                    _orderStatusList.Add("");
                }
                else
                {
                    _orderStatusList.Add(item.Name);
                }
            }
            foreach (var item in _progressStatusRepository.GetAll())
            {
                if (item == null)
                {
                    _progressStatusList.Add("");
                }
                else
                {
                    _progressStatusList.Add(item.Name);
                }
            }

        }


        public void PrintAccountStatus()
        {
            foreach (var accountStatus in _accountStatusList)
            {
                //System.Diagnostics.Debug.WriteLine("================" + accountStatus.Name);
            }
        }


    }
}