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
        private string m_Manufacturer;
        private float m_AirPreasure;
        private float m_MaxAirPreasure;

        public Wheel (string i_manufacturer, float i_airPreasure, float i_maxAirPreasure)
        {
            this.m_Manufacturer = i_manufacturer;
            this.m_AirPreasure = i_airPreasure;
            this.m_MaxAirPreasure = i_maxAirPreasure;
        }

        public void InflateWheel (float i_airToAdd)
        {
            float expectedAirPreasure = m_AirPreasure + i_airToAdd;
            if (expectedAirPreasure <= m_MaxAirPreasure)
            {
                m_AirPreasure = expectedAirPreasure;
            } else
            {
                throw new ValueOutOfRangeException(k_MinAirPreasure,m_MaxAirPreasure);
            }
        }
    }
}
