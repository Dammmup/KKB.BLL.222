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
