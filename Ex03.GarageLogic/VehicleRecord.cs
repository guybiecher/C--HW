using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus { Repair, Repaired, Paid }

<<<<<<< HEAD
    public class VehicleRecord
=======
    public class VechicleRecord
>>>>>>> 536e78f75b0aef59ff414650dda4b05abc45cb4d
    {
        private readonly string m_VehicleOwnerName;
        private readonly string m_VehicleOwnerPhoneNum;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

<<<<<<< HEAD
        public VehicleRecord (string i_VehicleOwnerName, string i_VehicleOwnerPhoneNum, string i_VehicleStatus, Vehicle i_Vehicle)
=======
        public string VehicleOwnerName => m_VehicleOwnerName;
        public string VehicleOwnerPhoneNum => m_VehicleOwnerPhoneNum;

        public eVehicleStatus VehicleStatus { get => m_VehicleStatus; set => m_VehicleStatus = value; }
        public Vehicle Vehicle { get => m_Vehicle;}

        public VechicleRecord (string i_VehicleOwnerName, string i_VehicleOwnerPhoneNum, eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
>>>>>>> 536e78f75b0aef59ff414650dda4b05abc45cb4d
        {
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhoneNum = i_VehicleOwnerPhoneNum;
            VehicleStatus = i_VehicleStatus;
            m_Vehicle = i_Vehicle;
        }

        
    }
}
