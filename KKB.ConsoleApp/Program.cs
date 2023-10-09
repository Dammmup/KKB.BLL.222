using KKB.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KKB.ConsoleApp
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Menu.FirstMenu();
            Console.ReadKey();


          

            StringBuilder sb = new StringBuilder("Hello world!");
            sb.IndexOf('!');

            int index = StringBuilderExtension.IndexOf(sb, '!');
        }
     


    }

    public static class StringBuilderExtension
    {
        public static Int32 IndexOf(this StringBuilder sb,Char value)
        {
            for(int i=0;i<sb.Length;i++)
            {
                if (sb[i] == value) return i;
            }
            return -1;
        }
    }
}
