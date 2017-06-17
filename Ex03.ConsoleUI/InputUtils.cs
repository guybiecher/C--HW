using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class InputUtils
    {
        public static bool IsValidActionChoice (string i_Input)
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

        internal static bool IsValidLicenseNumber(string userInput)
        {
            throw new NotImplementedException();
        }
    }
}
