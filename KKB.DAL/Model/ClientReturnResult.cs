using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class ClientReturnResult
    {
        public Exception Exception { get; set; }
        public Client Client { get; set; }
        public bool isError { get; set; }
    }
    public class AccountReturnResult
    {
        public Exception Exception { get; set; }
        public Account Account { get; set; }
        public List<Account> Accounts { get; set; }
        public bool isError { get; set; }
    }
}
