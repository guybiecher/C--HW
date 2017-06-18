using System;
using System.Collections.Generic;
using System.Text;

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


        public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
        {
            this.m_Model = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Engine = i_Engine;
            this.Wheels = i_Wheels;
        }

        protected static List<Wheel> CreateWheels(int i_NumberOfWheels, string i_Manufacturer, float i_AirPreasure, float i_MaxAirPreasure)
        {
            List<Wheel> wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                if (i_AirPreasure > i_MaxAirPreasure)
                {
                    throw new ValueOutOfRangeException("Air preasure", 0f, i_MaxAirPreasure);
                }
                else
                {
                    wheels.Add(new Wheel(i_Manufacturer, i_AirPreasure, i_MaxAirPreasure));
                }
            }
            return wheels;
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.InflateWheel(wheel.MaxAirPreasure - wheel.AirPreasure);
            }
        }

        public override string ToString()
        {
            StringBuilder wheelsString = new StringBuilder();
            foreach (Wheel wheel in m_Wheels)
            {
                wheelsString.Append(" Wheel: " + wheel.ToString() + "\r\n");
            }
            return String.Format("Vehicle Model : {0} ," +
                "Vehicle License Number : {1} \r\n" +
                "Vehicle Engine :\r\n {2} \r\n" +
                "Vehicle Wheels :\r\n{3}",
                m_Model,
                m_LicenseNumber,
                m_Engine.ToString(),
                wheelsString);
        }
    }
}
