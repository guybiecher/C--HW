using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        public ElectricEngine (float i_EnergyLevel, float i_MaxEnergyLevel) :
            base (i_EnergyLevel, i_MaxEnergyLevel)
        {

        }

        public void ChargeBattery (float i_HoursToCharge)
        {
            FillEnergy(i_HoursToCharge);
        }
    }
}
