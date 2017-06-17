using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    enum eFuelType { Soler, Octan95, Octan96, Octan98}

    class GasEngine : Engine
    {
        private eFuelType m_FuelType;

        public GasEngine (string i_FuelType, float i_EnergyLevel, float i_MaxEnergyLevel) :
            base (i_EnergyLevel, i_MaxEnergyLevel)
        {
            m_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_FuelType);
        }

        public void FillFuel (int i_FuelAmmount, string i_FuelType)
        {

        }
    }
}
