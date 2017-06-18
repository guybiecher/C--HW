using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        private const string k_EngineType = "Electric";

        public ElectricEngine(float i_EnergyLevel, float i_MaxEnergyLevel) :
            base(i_EnergyLevel, i_MaxEnergyLevel)
        {

        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            FillEnergy(i_HoursToCharge);
        }

        public override string ToString()
        {

            return base.ToString() + String.Format("Engine Type: {0}, ", k_EngineType);
        }
    }
}
