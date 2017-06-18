using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class InputUtils
    {
        internal const string k_NoFilter = "NO FILTER";

        public static bool IsValidActionChoice(string i_Input)
        {
            bool result;
            int parsedInput;
            bool isValidInputType = int.TryParse(i_Input, out parsedInput);

            if (isValidInputType)
            {
                if ((parsedInput >= 1) && (parsedInput <= 8))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        internal static string CheckFilterChoice(string i_UserInput)
        {
            return i_UserInput == "" ? k_NoFilter : i_UserInput;
        }
    }
}
