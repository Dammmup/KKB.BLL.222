using KKB.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KKB.DAL.Model;
using KKB.DAL;
using KKB.DAL.Interfaces;

namespace KKB.BLL.Model
{
    public class ServiceClient
    {
        private readonly IRepository<Client> repo;
        private readonly IMapper iMapper=null;
        public ServiceClient(string connectionString)
        {
            repo = new Repository<Client>(connectionString);
            iMapper = BLLSettings.Init().CreateMapper();
        }

        /// <summary>
        /// Регестрация
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RegisterClient(ClientDTO client)
        {
            ReturnResult<Client> result = new ReturnResult<Client>();          
            repo.Create(iMapper.Map<Client>(client));
            return !result.isError;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public IClientDTOShort AuthorizeClient(string Email, string Password)
        {
            ReturnResult<Client> result = new ReturnResult<Client>();

            result = repo.Get();//вернуть всех клиентов
            if(result.isError)
            {
                throw new ArgumentException("Error,try later");
            }
            var client = result.Datas
                .FirstOrDefault(f=>f.Email==Email && f.Password==Password);
            return iMapper.Map<ClientDTO>(client);
        }

        /// <summary>
        /// Изменить данные клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool UpdateClient(ClientDTO client)
        {
            ReturnResult<Client> result=new ReturnResult<Client>();
            result=repo.Update(iMapper.Map<Client>(client));
            return result.isError;
            
        }
    }
}
