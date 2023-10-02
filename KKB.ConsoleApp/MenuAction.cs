using KKB.BLL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.ConsoleApp
{
    public class MenuAction
    {
        readonly string path = "";

        public MenuAction()
        {
            path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool Register()
        {
            ClientDTO client = new ClientDTO();

            Console.Write("Name: ");
            client.Name = Console.ReadLine();

            Console.Write("SurName: ");
            client.SurName = Console.ReadLine();

            Console.Write("Dob: ");
            client.Dob = DateTime.Parse(Console.ReadLine());

            Console.Write("Email: ");
            client.Email = Console.ReadLine();

            Console.Write("PhoneNumber: ");
            client.PhoneNumber = Console.ReadLine();

            Console.Write("Password: ");
            client.Password = Console.ReadLine();
            KKB.BLL.Model.ServiceClient service =
                new BLL.Model.ServiceClient(path);

            return service.RegisterClient(client);
        }
        public IClientDTOShort Auth()
        {
            Console.Write("email: ");
            string email = Console.ReadLine();

            Console.Write("password: ");
            string password = Console.ReadLine();

            KKB.BLL.Model.ServiceClient service =
                new BLL.Model.ServiceClient(path);

            try
            {
                return service.AuthorizeClient(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public void UpdateClient(ClientDTO client)
        {

            Console.WriteLine("введите новый емайл");
            client.Email = Console.ReadLine();
            Console.WriteLine("введите новый телефон");
            client.PhoneNumber = Console.ReadLine();
            KKB.BLL.Model.ServiceClient srvc = new KKB.BLL.Model.ServiceClient(path);
            if (srvc.UpdateClient(client) != true)
            {
                Console.WriteLine("произошла ошибка");
            }
            else
            {
                Console.WriteLine("данные обновлены успешно");
            }
        }
        public void ShowAccount(int clientid)
        {
            ServiceAccount service = new ServiceAccount(path);
            var data = service.GetAllAccounts(clientid);
            Console.WriteLine(": {0}", data.message);
           
                foreach (AccountDTO account in data.accounts)
                {
                    Console.WriteLine("{0} {1}\t{2} {3}",
                        account.Id,
                        account.IBAN,
                        account.Balance,
                        account.Currence);
                }
            Console.WriteLine("---------------------");
            Console.WriteLine("Choose bill: ");
            int seletedAccount=Int32.Parse(Console.ReadLine());
            var accunt = service.GetAccount(seletedAccount);
            if(accunt != null)
            {
                Console.Clear();
                Console.WriteLine("{0}",accunt.IBAN);
                Console.WriteLine("{0:dd.MM.yyyy}",accunt.CreateDate);
                Console.WriteLine("balance {0}",accunt.Balance);
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Choose operation:");
                Console.WriteLine("1. Pay Money");
                Console.WriteLine("2. Pay User");
                Console.WriteLine("3. Bill");

            }
            
        }
    }
}
