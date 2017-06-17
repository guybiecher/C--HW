using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class UI
    {

        public static void Initiate ()
        {
            Console.WriteLine("Wellcome to our garage!!");
            Console.WriteLine("How can I help you today?");
        }

        public static void ShowGarageActions ()
        {
            Console.WriteLine("Please choose one of the actions below by typing the number next to the action:");
            Console.WriteLine(
                "1. Check in a new vehicle" +
                "2. Show registered vehicles license numbers" +
                "3. Change registered vehicle status" +
                "4. Inflate vehicle wheels to maximum" +
                "5. Fuel up a gas vehicle" +
                "6. Charge an electric vehicle" +
                "7. Show full vehicle details" +
                "8. Exir garage"
                );
        }

        public static string GetUserActionInput()
        {
            string userInput = Console.ReadLine();
            bool validInput = InputUtils.IsValidActionChoice(userInput);

            while (!validInput)
            {
                Console.WriteLine("Invalid action choice, please type a number between 1 and 8");
                userInput = Console.ReadLine();
                validInput = InputUtils.IsValidActionChoice(userInput);
            }

            return userInput;
        }

        public static string GetLicenseNumberInput ()
        {
            Console.WriteLine("Please insert a license number");
            string userInput = Console.ReadLine();
            bool isValidInput = InputUtils.IsValidLicenseNumber(userInput);

            while (!isValidInput)
            {
                Console.WriteLine("Invalid license number, please try again");
                userInput = Console.ReadLine();
                isValidInput = InputUtils.IsValidLicenseNumber(userInput);
            }

            return null;
        }

        internal static void NoRecordFound()
        {
            Console.WriteLine("No records with that license number found in the garage"); ;
        }
    }
}
