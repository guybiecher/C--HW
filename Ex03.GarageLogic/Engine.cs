using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Engine
    {
        private float m_EnergyLevel;
        private float m_MaxEnergyLevel;
        
        public Engine (float i_EnergyLevel, float i_MaxEnergyLevel)
        {
            m_EnergyLevel = i_EnergyLevel;
            m_MaxEnergyLevel = i_MaxEnergyLevel;
        }
    }
}
