using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private Engine m_Engine;
        private float  m_EnergyLevel;
        private ArrayList m_Wheels;

        public string Model { get => m_Model; set => m_Model = value; }
        public string LicenseNumber { get => m_LicenseNumber; set => m_LicenseNumber = value; }
        public Engine Engine { get => m_Engine; set => m_Engine = value; }
        public float EnergyLevel { get => m_EnergyLevel; set => m_EnergyLevel = value; }
        public ArrayList Wheels { get => m_Wheels; set => m_Wheels = value; }
        

        public Vehicle(string i_Model ,string i_LicenseNumber ,Engine i_Engine ,float i_EnergyLevel ,ArrayList i_Wheels)
        {
            this.m_Model = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Engine = i_Engine;
            this.m_EnergyLevel = i_EnergyLevel;
            this.Wheels = i_Wheels;
        }



    }
}
