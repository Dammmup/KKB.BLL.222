using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class ServiceClient
    {
        private ClientRepository repo = null;

        public ServiceClient(string connectionString)
        {
            repo = new ClientRepository(connectionString);
        }

        /// <summary>
        /// Регестрация
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RegsterClient(Client client)
        {
            //if(repo.GetClientData(client.Email, client.Password)==null)
            //{

            //}

            repo.CreateClient(client);

            return true;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Client AuthorizeClient(string Email, string Password)
        {
            return repo.GetClientData(Email, Password);
        }

        /// <summary>
        /// Изменить данные клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool UpdateClient(Client client)
        {

            return true;
        }


    }
}
