using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    enum eCarColor {
        Blue,
        White,
        Yellow,
        Black
    }

    enum eNumberOfDoors{
        TwoDoors = 2,
        ThreeDoors = 3,
        FourDoors = 4,
        FiveDoors = 5
    }
   
    class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const float k_MaxWheelPressure = 33f;


        private eCarColor m_Color;
        private eNumberOfDoors m_NumOfDoors;
        private Engine m_Engine;

        public Car (eCarColor i_Color,Engine i_Engine,eNumberOfDoors i_NumofDoors, string i_Model, string i_LicenseNumber, List<Wheel> i_Wheels) :
            base(i_Model, i_LicenseNumber, i_Engine, i_Wheels)
        {
            m_Color = i_Color; 
            m_NumOfDoors = i_NumofDoors;
        }

        public static List<Wheel> CreateCarWheels(string i_Manufacturer, float i_AirPreasure)
        {
            return CreateWheels(k_NumberOfWheels, i_Manufacturer, i_AirPreasure,k_MaxWheelPressure);
        }

    }
}
