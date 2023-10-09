using KKB.BLL.Enum;
using KKB.BLL.Model;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Cache;

namespace KKB.ConsoleApp
{
    
    public static class Menu
    {
        static string path = "";

        static Menu()
        {
            path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public static void FirstMenu()
        {
            MenuAction menuAction = new MenuAction();

            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("1. Авторизация");
            Console.WriteLine("2. Регистрация");
            Console.WriteLine("3. Выход");

            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        IClientDTOShort clent = menuAction.Auth();

                        if (clent == null)
                        {
                            Console.WriteLine("Авторизация не прошла");
                        }
                        else
                        {
                            //Console.WriteLine("Авторизация успешна!");
                            SecondMenu(clent);
                        }
                        break;
                    }
                case 2:
                    Console.Clear();
                    Console.WriteLine("Register user");
                    if (menuAction.Register())
                    {
                        Console.Clear();
                        FirstMenu();
                    }
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void SecondMenu(IClientDTOShort client)
        {
            MenuAction menuAction = new MenuAction();
            Console.Clear();
            Console.WriteLine("Добро пожаловать {0}", client.Name);
            Console.WriteLine("Ваши счета: ...");
            menuAction.ShowAccount(client.Id);
            Console.WriteLine("");
            Console.WriteLine("Do you want open new bill? yes/no: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                    {
                        Console.WriteLine("Choose currence: ");
                        Currency curr;
                        for(curr=Currency.kzt;curr<=Currency.eur;curr++ )
                        {
                            Console.WriteLine("-> {0}. {1}",(int)curr,curr);
                        }
                        int selectCurrency = Int32.Parse(Console.ReadLine());
                        Random rand = new Random();
                        AccountDTO account = new AccountDTO();
                        account.Balance = 0;
                        account.Currence = (Currency)selectCurrency;                     /*(Currency)Enum.Parse(typeof(Currency),"kzt";*/
                        account.CreateDate = DateTime.Now;
                        account.ExpireDate = account.CreateDate.AddDays(15);
                        account.TypeCard = 1;
                        account.IBAN = "KZ" + rand.Next(100, 999);
                        account.ClientId=client.Id;

                        ServiceAccount serviceAccount = new ServiceAccount(path);
                        var result= serviceAccount.CreateAccountClient(account);
                        
                        if(!result.result)
                            Console.WriteLine(result.message);
                        else
                            SecondMenu(client);
                        break;
                    }
            }
        }
       
    }
}
