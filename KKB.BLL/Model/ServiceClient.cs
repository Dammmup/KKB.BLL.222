using KKB.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KKB.DAL.Model;

namespace KKB.BLL.Model
{
    public class ServiceClient
    {
        private readonly ClientRepository repo = null;
        private readonly IMapper iMapper;
        public ServiceClient(string connectionString)
        {
            repo = new ClientRepository(connectionString);
        }

        /// <summary>
        /// Регестрация
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RegisterClient(ClientDTO client)
        {
            try
            {
                repo.CreateClient(iMapper.Map<Client>(client));
            }
            catch
            {

                throw new ArgumentException("ВОЗНИКЛА ОШИБКА ПОВТОРИТЕ ПОЗЖЕ");
            }
            return true;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public ClientDTO AuthorizeClient(string Email, string Password)
        {
            ClientDTO client = null;
            try
            {
                var _client = repo.GetClientData(Email, Password);
                _client = iMapper.Map<Client>(client);

            }
            catch
            {
                throw new ArgumentException("Во3никла ошибка, попробуйте позже");
            }

            return client;
        }

        /// <summary>
        /// Изменить данные клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool UpdateClient(ClientDTO client)
        {
            try
            {
                return repo.UpdateClient(iMapper.Map<Client>(client));
            }
            catch
            {
                return false;
            }
        }


    }
}
