using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private Engine m_Engine;
        private List<Wheel> m_Wheels;

        public string Model { get => m_Model; set => m_Model = value; }
        public string LicenseNumber { get => m_LicenseNumber; set => m_LicenseNumber = value; }
        public Engine Engine { get => m_Engine; set => m_Engine = value; }
        public List<Wheel> Wheels { get => m_Wheels; set => m_Wheels = value; }
        

        public Vehicle(string i_Model ,string i_LicenseNumber ,Engine i_Engine , List<Wheel> i_Wheels)
        {
            this.m_Model = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Engine = i_Engine;
            this.Wheels = i_Wheels;
        }

        protected static List<Wheel> CreateWheels(int i_NumberOfWheels, string i_Manufacturer, float i_AirPreasure, float i_MaxAirPreasure)
        {
            List<Wheel> wheels = new List<Wheel>();
            for(int i = 0; i < i_NumberOfWheels; i++)
            {
                wheels.Add(new Wheel(i_Manufacturer, i_AirPreasure, i_MaxAirPreasure));
            }
            return wheels;
        }

        public void InflateWheelsToMax()
        {

        }



    }
}
