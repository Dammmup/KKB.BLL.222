using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace KKB.BLL.Model
{
    public class ClientDTO
    {
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

        public string Shortname
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(MiddleName))
                {
                    return string.Format(("{0} {1}. {2}."),
                            Name, SurName[0], MiddleName[0]);
                }
                else
                {
                    return string.Format("{0} {1}.", Name, SurName[0]);
                }
            }
        }
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

        public List<AddressDTO> Address { get; set; }
        public List<AccountDTO> Account { get; set; }
    }
}
