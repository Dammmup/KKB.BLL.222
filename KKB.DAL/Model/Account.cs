using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public int Currence { get; set; }
        public double Limit { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Status { get; set; } = true;
        public int TypeCard { get; set; } //debit - credit
        public string IBAN { get; set; } //KZ05403542054C854


        public double DaysRemain
        {
            get
            {
                return (ExpireDate - CreateDate).TotalDays;
            }
        }

        public bool IdActive
        {
            get
            {
                return Status;
            }
        }
    }
}
