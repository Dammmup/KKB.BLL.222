using KKB.BLL.Model;

using System;
using System.Collections.Generic;
using System.Net.Cache;

namespace KKB.ConsoleApp
{
    public static class Menu
    {
        public class Random
        {
            public static int rand = new Random();


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
                        ClientDTO clent = menuAction.Auth();

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
        public static void SecondMenu(ClientDTO client)
        {
            MenuAction menuAction = new MenuAction();
            Console.Clear();
            Console.WriteLine("Добро пожаловать {0}", client.Shortname);
            Console.WriteLine("Ваши счета: ...");
            menuAction.ShowAccount(client.Id);
            Console.WriteLine("");
            Console.WriteLine("Do you want open new bill? yes/no: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "yes":
                    {
                        AccountDTO account = new AccountDTO();
                        account.Balance = 0;
                        account.Currence = 398;
                        account.CreateDate = DateTime.Now;
                        account.ExpireDate = account.CreateDate.AddDays(15);
                        account.TypeCard = 1;
                        account.IBAN = "KZ" + Rand.Next(100, 999);
                        break;
                    }
            }
        }
        public (string message, List<AccountDTO> accounts) GetAllAcounts(int clientid)
        {
            var result = repo
        }
        public void CreateAccountClient(AccountDTO account)
        {
            var result = Reques
        }
    }
}
