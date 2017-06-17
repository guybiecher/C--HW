using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex03.GarageLogic
{
    enum eColor {
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
        private eColor m_Color;
        private int m_NumOfDoors;
        private Engine m_Engine;

        public Car (string i_Color,Engine i_Engine,int i_NumofDoors, string i_Model, string i_LicenseNumber, float i_EnergyLevel, ArrayList i_Wheels) :
            base(i_Model, i_LicenseNumber, i_Engine, i_EnergyLevel, i_Wheels)
        {
            m_Color = (eColor)Enum.Parse(typeof(eColor), i_Color); 
            m_NumOfDoors = i_NumofDoors;
        }

    }
}
