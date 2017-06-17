using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    enum eVehicleStatus { Repair, Repaired, Paid }

    public class VehicleRecord
    {
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhoneNum;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleRecord (string i_VehicleOwnerName, string i_VehicleOwnerPhoneNum, string i_VehicleStatus, Vehicle i_Vehicle)
        {
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhoneNum = i_VehicleOwnerPhoneNum;
            m_VehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_VehicleStatus);
            m_Vehicle = i_Vehicle;
        }
    }
}
