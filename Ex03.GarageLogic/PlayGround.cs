using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class PlayGround
    {
        enum eVehicleStatus { Repair , Dont}
        public static void Main()
        {
            string i_VehicleStatus = "Dont";
            eVehicleStatus vehicleStatusParsedToEnum = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_VehicleStatus);
            Console.WriteLine(vehicleStatusParsedToEnum.ToString());
        }
    }
}
