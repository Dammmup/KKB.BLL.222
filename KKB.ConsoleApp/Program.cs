using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Register();
            Auth();

        }

        static void Register()
        {
            Client client = new Client();

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

            string path = @"C:\Temp\KKBData.db";
            KKB.BLL.Model.ServiceClient service =
                new BLL.Model.ServiceClient(path);

            service.RegsterClient(client);
        }

        static void Auth()
        {
            Console.Write("email: ");
            string email = Console.ReadLine();

            Console.WriteLine("password: ");
            string password = Console.ReadLine();

            string path = @"C:\Temp\KKBData.db";
            KKB.BLL.Model.ServiceClient service =
                new BLL.Model.ServiceClient(path);

            service.AuthorizeClient(email, password);
        }
    }
}
