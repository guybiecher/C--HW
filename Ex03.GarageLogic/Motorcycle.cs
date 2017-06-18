using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    enum eLicenseType
    {
        A,
        AB,
        A2,
        B1
    }

    class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private eLicenseType m_LicenseType;
        private float m_EngineCC;
        private Engine m_Engine;

        public Motorcycle (eLicenseType i_LicenseType,Engine i_Engine , float i_EngineCC, string i_Model, string i_LicenseNumber, List<Wheel> i_Wheels) :
            base(i_Model, i_LicenseNumber, i_Engine, i_Wheels)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCC = i_EngineCC;
        }

        public static List<Wheel> CreateMotorCycleWheels(string i_Manufacturer, float i_AirPreasure, float i_MaxAirPreasure)
        {
            return CreateWheels(k_NumberOfWheels, i_Manufacturer, i_AirPreasure, i_MaxAirPreasure);
        }
    }
}
