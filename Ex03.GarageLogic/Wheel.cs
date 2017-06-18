using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const float k_MinAirPreasure = 0;
        private float m_AirPreasure;
        private readonly string m_Manufacturer;
        private readonly float m_MaxAirPreasure;

        public float MaxAirPreasure { get => m_MaxAirPreasure; }
        public float AirPreasure { get => m_AirPreasure; set => m_AirPreasure = value; }

        public Wheel(string i_manufacturer, float i_airPreasure, float i_maxAirPreasure)
        {
            this.m_Manufacturer = i_manufacturer;
            this.AirPreasure = i_airPreasure;
            this.m_MaxAirPreasure = i_maxAirPreasure;
        }

        public void InflateWheel(float i_airToAdd)
        {
            float expectedAirPreasure = AirPreasure + i_airToAdd;
            if (expectedAirPreasure <= MaxAirPreasure)
            {
                AirPreasure = expectedAirPreasure;
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinAirPreasure, MaxAirPreasure);
            }
        }

        public override string ToString()
        {
            return String.Format("Wheel Manufacturer : {0} ," +
                " Wheel Air Preasure : {1} ," +
                " Wheel Max Air Preasure {2} ,",
                m_Manufacturer,
                m_AirPreasure,
                m_MaxAirPreasure
                );
        }
    }
}
