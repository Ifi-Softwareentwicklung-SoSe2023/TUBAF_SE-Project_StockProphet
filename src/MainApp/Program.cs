using System;
using StockProphetLib;


namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StockProphet prophet = new StockProphet();


            Console.WriteLine("========================================");
            Console.WriteLine("Greetings, explorer of the stock market."); 
            Console.WriteLine("The Stock Prophet welcomes you!");
            Console.WriteLine("========================================");
            Console.WriteLine();


            while(true)
            {
                Console.Write("Please enter the name of a company to search for: ");
                string keyword = Console.ReadLine();


                StockProphet.Prophesy(keyword);


                Console.Write("New input? (Y): ");
                if(Console.ReadLine() != "Y") break;

                Console.Clear();   
            }
        }
    }
}
