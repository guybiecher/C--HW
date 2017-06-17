using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex03.GarageLogic
{
    enum eLicenseType { A, AB, A2, B1}

    class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCC;
        private Engine m_Engine;

        public Motorcycle (string i_LicenseType,Engine i_Engine , int i_EngineCC, string i_Model, string i_LicenseNumber, float i_EnergyLevel, ArrayList i_Wheels) :
            base(i_Model, i_LicenseNumber, i_Engine, i_EnergyLevel, i_Wheels)
        {
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_LicenseType);
            m_EngineCC = i_EngineCC;
        }
    }
}
