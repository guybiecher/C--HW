using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float k_MinEnergyLevel = 0;
        protected float m_EnergyLevel;
        protected float m_MaxEnergyLevel;

        public Engine(float i_EnergyLevel, float i_MaxEnergyLevel)
        {
            m_EnergyLevel = i_EnergyLevel;
            m_MaxEnergyLevel = i_MaxEnergyLevel;
        }

        protected void FillEnergy(float i_AmountOfEnergyToAdd)
        {
            float totalFuel = i_AmountOfEnergyToAdd + m_EnergyLevel;
            if (totalFuel >= m_MaxEnergyLevel)
            {
                throw new ValueOutOfRangeException("Energy", k_MinEnergyLevel, m_MaxEnergyLevel);
            }
            m_EnergyLevel = totalFuel;

        }

        public override string ToString()
        {
            return String.Format("Engine Energy Level : {0} ," +
                "Engine Maximum Energy Level : {1} ,",
                m_EnergyLevel,
                m_MaxEnergyLevel
                );
        }
    }
}
