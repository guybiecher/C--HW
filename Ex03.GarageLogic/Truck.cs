using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private bool m_Toxic;
        private float m_MaxWeight;

        public Truck (bool i_Toxic ,Engine i_Engine ,float i_MaxWeight ,string i_Model ,string i_LicenseNumber ,List<Wheel> i_Wheels) :
            base (i_Model ,i_LicenseNumber, i_Engine, i_Wheels)
        {

        }

        public static List<Wheel> CreateTruckWheels(string i_Manufacturer, float i_AirPreasure, float i_MaxAirPreasure)
        {
            return CreateWheels(k_NumberOfWheels, i_Manufacturer, i_AirPreasure, i_MaxAirPreasure);
        }
    }
}
