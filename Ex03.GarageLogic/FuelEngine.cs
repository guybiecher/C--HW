using System;

namespace Ex03.GarageLogic
{
    enum eFuelType {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

    class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_EnergyLevel, float i_MaxEnergyLevel) :
            base(i_EnergyLevel, i_MaxEnergyLevel)
        {
            m_FuelType = i_FuelType;
        }

        public void FillFuel(float i_AmountFuelToAdd, eFuelType i_FuelType)
        {
            if (!i_FuelType.Equals(m_FuelType))
            {
                throw new ArgumentException("Wrong fuel type");
            }
            else
            {
                FillEnergy(i_AmountFuelToAdd);
            }
           
        }
    }
}

