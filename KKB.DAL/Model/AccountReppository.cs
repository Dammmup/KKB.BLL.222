using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class AccountRepository
    {
        private readonly string connectionString = "";


        public AccountRepository(string connectionSting)
        {
            this.connectionString = connectionSting;
        }

        public AccountReturnResult GetAccounts()
        {
            AccountReturnResult result = new AccountReturnResult();
            result.Accounts = null;

            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    result.Accounts = db.GetCollection<Account>("Account")
                        .FindAll()
                        .ToList();
                }
            }
            catch (Exception ex)
            {

                result.isError = true;
                result.Exception = ex;
            }
            return result;
        }
        public bool isError
        {
            get; set;
        } = false;
        public Exception Exception { get; set; }
        public List<Account> Accounts { get; set; }

        /// <summary>
        /// search client at id
        /// </summary>
        /// <param name="clientid"></param>
        /// <returns></returns>
        public AccountReturnResult GetAccounts(int clientid)
        {
            AccountReturnResult result = new AccountReturnResult();
            result.Accounts = null;

            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    result.Accounts = db.GetCollection<Account>("Account")
                        .FindAll()
                        .Where(w => w.Clientid == clientid)
                        .ToList();
                }
            }
            catch (Exception ex)
            {

                result.isError = true;
                result.Exception = ex;
            }
            return result;
        }

        public AccountReturnResult CreateAccount(Account account)
        {
            AccountReturnResult result = new AccountReturnResult();
            result.Accounts = null;

            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var accounts = db.GetCollection<Account>("Accounts");
                    accounts.Insert(account);
                }
            }
            catch (Exception ex)
            {

                result.isError = true;
                result.Exception = ex;
            }
            return result;
        }
    }
}
