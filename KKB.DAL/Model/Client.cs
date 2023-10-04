using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class Client
    {
        public int Clientid { get;  }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SurName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Dob { get; set; }
        /// <summary>
        /// Возраст клиента
        /// </summary>
        public int GetAge
        {
            get
            {
                return DateTime.Now.Year - Dob.Year;
            }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }

        public string Password { get; set; }

        public List<Address> Address { get; set; }
        public List<Account> Account { get; set; }
    }
}
