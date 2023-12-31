﻿using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using KKB.DAL;
using KKB.DAL.Interfaces;
using KKB.BLL.Enum;

namespace KKB.BLL.Model
{
    public class ServiceAccount:Service<Account>
    {
        //private readonly IRepository<Account> repo = null;
        //private readonly IMapper iMapper;

        public ServiceAccount(string connectionstring):base(connectionstring)
        {
          
        }

        public (string message, List<AccountDTO> accounts) GetAllAccounts(int clientid)
        {

            var result = repo.Get();
               
            return ((result.isError==true)?result.Exception.Message:"",
                iMapper.Map<List<AccountDTO>>(result.Datas.Where(w => w.Clientid.Equals(clientid)))); //возвращает метод, определенного клиента
        }
        public (string message, List<AccountDTO> accounts) GetAllAccounts(int clientid, Currency currency)
        {

            var result = repo.Get();


            return ((result.isError == true) ? result.Exception.Message : "",
                iMapper.Map<List<AccountDTO>>(result.Datas.Where(w => w.Clientid.Equals(clientid) && w.Currence == (int)currency))); //возвращает метод, определенного клиента
        }


        public double GetAccountBalance(int clientId)
        {
            AccountDTO totalBalance = null;
            foreach(AccountDTO acc in GetAllAccounts(clientId).accounts)
            {
                totalBalance = acc + totalBalance;
            }
            return totalBalance.Balance;
        }

     
        public(bool result,string message) CreateAccountClient(AccountDTO account)
        {
            var result=repo.Create(iMapper.Map<Account>(account));
            return (result.isError,result.Exception!=null?result.Exception.Message:"");
        }
        /// <summary>
        /// метод который возвращает информацию по счету
        /// </summary>
        /// <param name="accountId">Id счета</param>
        /// <returns></returns>
        public AccountDTO GetAccount(int accountId)
        {
            return iMapper.Map<AccountDTO>(repo.GetData(accountId));
        }

    }
}
