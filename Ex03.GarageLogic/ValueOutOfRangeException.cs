using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        public float MaxValue { get => m_MaxValue; }

        private float m_MinValue;
        public float MinValue { get => m_MinValue; }

        public ValueOutOfRangeException(string i_ValueType, float i_MinValue, float i_MaxValue) : base(String.Format("{0} value is out of range , range is between {1} to {2}", i_ValueType, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

    }
}
