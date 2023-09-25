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

        public List<Client> GetAllClients(out string message)
        {
            List<Client> clients = null;
            message = "";

            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    clients = db.GetCollection<Client>("Client")
                  .FindAll()
                  .ToList();
                }
            }
            catch (ArgumentNullException ae)
            {
                message = ae.Message;
            }
            catch
               when (string.IsNullOrWhiteSpace(connectionString))
            {
                message = "Строка подключения к БД не корректна";
            }
            catch (Exception myError)
            {
                message = myError.Message;
            }
            finally
            {
                // db.Dispose();
            }

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
            try
            {
                string message = "";
                List<Client> data = GetAllClients(out message);

                if (!string.IsNullOrWhiteSpace(message))
                    throw new ArgumentException(message);

                var client = data
                    .FirstOrDefault(a => a.Email == Email
                    && a.Password == Password);

                return client;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Метод который создает пользователя
        /// </summary>
        /// <param name="client">Данные пользователя</param>
        /// <returns></returns>
        public Client CreateClient(Client client)
        {
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var clients = db.GetCollection<Client>("Client");

                    clients.Insert(client);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return client;
        }
        public bool UpdateClient(Client client)
        {
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var clients = db.GetCollection<Client>("Client");
                    clients.Update(client);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
