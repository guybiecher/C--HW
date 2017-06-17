using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Dictionary<string, string> test = new Dictionary<string, string>
            {
                { "Tal", "1" },
                { "Liad", "2" }
            };
            Console.WriteLine(test.Values);
            GarageManager myGarage = new GarageManager();
            myGarage.start(); 
        }
    }
}
