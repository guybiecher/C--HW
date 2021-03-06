﻿using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        public static void Initiate()
        {
            Console.WriteLine("Wellcome to our garage!! How can I help you today?\r\n");
        }

        public static void ShowGarageActions()
        {
            Console.WriteLine("Please choose one of the actions below by typing the number next to the action:");
            Console.WriteLine(
                "1. Check in a new vehicle\r\n" +
                "2. Show registered vehicles license numbers\r\n" +
                "3. Change registered vehicle status\r\n" +
                "4. Inflate vehicle wheels to maximum\r\n" +
                "5. Fuel up a gas vehicle\r\n" +
                "6. Charge an electric vehicle\r\n" +
                "7. Show full vehicle details\r\n" +
                "8. Exit garage"
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

            Console.Clear();
            return userInput;
        }

        public static string GetLicenseNumberInput()
        {
            Console.WriteLine("Please type in a license number");
            string userInput = Console.ReadLine();

            return userInput;
        }

        internal static void ShowVehicleDetails(VechicleRecord i_Record)
        {
            Console.WriteLine(i_Record.ToString());
        }

        internal static void NoRecordFound()
        {
            Console.WriteLine("No record with that license number found in the garage"); ;
        }

        internal static float GetChargeAmmountInput()
        {
            Console.Clear();
            Console.WriteLine("Please type in the ammount of energy to charge in minutes");
            string userInput = Console.ReadLine();
            float parsedInput;
            bool isValidInput = float.TryParse(userInput, out parsedInput);

            while (!isValidInput)
            {
                Console.WriteLine("Invalid charge ammount input, please try again");
                userInput = Console.ReadLine();
                isValidInput = float.TryParse(userInput, out parsedInput);
            }

            return parsedInput;
        }

        internal static void ShowAllRegisteredVehicles(List<string> i_LicenseNumbersList)
        {
            Console.Clear();
            Console.WriteLine("Here are the license numbers of the vehicles registered in the garage:\r\n");
            foreach (string record in i_LicenseNumbersList)
            {
                Console.WriteLine(record);
            }
        }

        internal static string GetVehicleStateInput()
        {
            Console.Clear();
            Console.WriteLine("Please type in the vehicles new state");
            return Console.ReadLine();
        }

        internal static string GetFuelTypeInput()
        {
            Console.Clear();
            Console.WriteLine("Please type in a gas type");
            return Console.ReadLine();
        }

        internal static float GetFuelAmmountInput()
        {
            Console.Clear();
            Console.WriteLine("Please type in the ammount of gas to fill");
            string userInput = Console.ReadLine();
            float parsedInput;
            bool isValidInput = float.TryParse(userInput, out parsedInput);

            while (!isValidInput)
            {
                Console.WriteLine("Invalid fuel ammount input, please try again");
                userInput = Console.ReadLine();
                isValidInput = float.TryParse(userInput, out parsedInput);
            }

            return parsedInput;
        }

        internal static string GetFilterInput()
        {
            Console.Clear();
            Console.WriteLine("Please type in a vehicles state to filter by, if you don't wish to filter, simply hit enter with no value typed in");
            string userInput = Console.ReadLine();

            return InputUtils.CheckFilterChoice(userInput);
        }

        internal static void ShowVehicleNewState(string i_VehicleState)
        {
            Console.WriteLine("Vehicle new state is: " + i_VehicleState);
        }

        internal static string GetOwnerNameInput()
        {
            Console.Clear();
            Console.WriteLine("Please type in a your name");
            return Console.ReadLine();
        }

        internal static string GetOwnerPhoneNumber()
        {
            Console.WriteLine("Please type in you phone number");
            return Console.ReadLine();
        }

        internal static string GetVehicleTypeInput(List<string> i_SupportedVehiclesList)
        {
            StringBuilder vehicleTypes = new StringBuilder();
            foreach (string vehicleType in i_SupportedVehiclesList)
            {
                vehicleTypes.Append(vehicleType + "\r\n");
            }
            Console.WriteLine("Please type in you vehicle type according to one of the types listed below:\r\n{0}", vehicleTypes);
            return Console.ReadLine();
        }

        internal static string GetGeneralInput(string i_Field, string i_VehicleType)
        {
            Console.WriteLine("Please type in your {0} {1}", i_VehicleType, i_Field);
            return Console.ReadLine();
        }

        internal static void PrintSuccess()
        {
            Console.WriteLine("Success!");
        }
    }
}
