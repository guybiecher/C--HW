﻿using System;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        public  float MaxValue { get => m_MaxValue; }

        private float m_MinValue;
        public  float MinValue { get => m_MinValue; }

        public ValueOutOfRangeException(float i_MinValue ,float i_MaxValue) : base(String.Format("Value is out of range , range is between {0} to {1}",i_MinValue,i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

    }
}