using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingXmlfrom.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(Console.ReadKey().Key != ConsoleKey.Escape)
            {
                ShowPropeties();
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }

        private static void ShowPropeties()
        {
            Console.Clear();
            Console.WriteLine("1.Add Item");
            Console.WriteLine("2.Remove Item");
            Console.WriteLine("3.Show all list");
        }
    }
}
