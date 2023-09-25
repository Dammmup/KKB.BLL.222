using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace KKB.BLL.Model
{
    public class ServiceAccount
    {
        private readonly AccountRepository repo = null;
        private readonly IMapper iMapper;

        public ServiceAccount(string connectionstring)
        {
            repo = new AccountRepository(connectionstring);
            iMapper = BLLSettings.Init().CreateMapper();
        }

        public (string message, List<AccountDTO> accounts) GetAllAccounts(int clientid)
        {
            var result = repo.GetAccounts(clientid);
            return ((result.isError==true)?result.Exception.Message:"", iMapper.Map<List<AccountDTO>>(result.Accounts));
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

        public static void Example01()
        {
            AccountDTO acc1 = new AccountDTO(1, 1000);
            AccountDTO acc2=new AccountDTO(2, 1000);
            AccountDTO acc3=new AccountDTO(3, 1000);
            var result = acc1 + acc2;
            var result2=acc2 + acc3;
        }
        public(bool result,string message) CreateAccountClient(AccountDTO account)
        {
            var result=repo.CreateAccount(iMapper.Map<Account>(account));
            return (result.isError,result.Exception!=null?result.Exception.Message:"");
        }
        /// <summary>
        /// метод который возвращает информацию по счету
        /// </summary>
        /// <param name="accountId">Id счета</param>
        /// <returns></returns>
        public AccountDTO GetAccount(int accountId)
        {
            return iMapper.Map<AccountDTO>(repo.GetAccountById(accountId));
        }

    }
}
