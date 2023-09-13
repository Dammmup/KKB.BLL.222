using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class ClientRepository
    {
        readonly string connectionString = "";
        public ClientRepository(string connectionString)
        {
            this.connectionString = connectionString;   
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();

            using (var db = new LiteDatabase(connectionString))
            {
                clients = db.GetCollection<Client>("Client")
                    .FindAll()
                    .ToList();

            }//Dispose()

            return clients;
        }

        /// <summary>
        /// Метод который возвращает есть ли клиент по Email и Password
        /// </summary>
        /// <param name="Email">Электроный адрес</param>
        /// <param name="Password">Пароль</param>
        /// <returns></returns>
        public Client GetClientData(string Email, string Password)
        {
            List<Client> data = GetAllClients();

            var client = data
                .FirstOrDefault(a=> a.Email == Email 
                && a.Password == Password);

            return client;
        }

        /// <summary>
        /// Метод который создает пользователя
        /// </summary>
        /// <param name="client">Данные пользователя</param>
        /// <returns></returns>
        public bool CreateClient(Client client)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var clients = db.GetCollection<Client>("Client");

                clients.Insert(client);
            }

            return true;
        }
    }
}
