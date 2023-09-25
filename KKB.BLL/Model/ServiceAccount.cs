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
            return (result.Exception.Message, iMapper.Map<List<AccountDTO>>(result.Accounts));
        }
    }
}
