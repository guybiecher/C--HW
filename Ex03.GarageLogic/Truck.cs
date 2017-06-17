using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_Toxic;
        private float m_MaxWeight;

        public Truck (bool i_Toxic, float i_MaxWeight, string i_Model, string i_LicenseNumber, float i_EnergyLevel, ArrayList i_Wheels) :
            base (i_Model, i_LicenseNumber, i_EnergyLevel, i_Wheels)
        {

        }
    }
}
