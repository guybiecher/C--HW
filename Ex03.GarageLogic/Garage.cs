using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private const float k_ParseMinuteToHours = 60f;
        private static Dictionary<string, VechicleRecord> m_VechicleRecords = null;
        
        public Garage()
        {
            m_VechicleRecords = new Dictionary<string, VechicleRecord>();
        }

        public bool IsVehicleListed(string i_LicenseNumber)
        {
            return m_VechicleRecords.ContainsKey(i_LicenseNumber);
        }

        public List<string> getAllLicenseNumbers(string filterByVechicleStatus)
        {
           bool useFilter = (filterByVechicleStatus == null) ? false : true;
           List<string> allCarsLicenseNumbers = new List<string>(); 
           foreach (KeyValuePair<string, VechicleRecord> vechicle in m_VechicleRecords)
            {
                if (!useFilter || vechicle.Value.VehicleStatus.Equals(filterByVechicleStatus))
                {
                    allCarsLicenseNumbers.Add(vechicle.Key);
                }
            }
            return allCarsLicenseNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VechileNewStatus)
        {
            m_VechicleRecords[i_LicenseNumber].VehicleStatus = i_VechileNewStatus;
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            m_VechicleRecords[i_LicenseNumber].Vehicle.InflateWheelsToMax();
        }

        public void ChargeVehicle(string licenseNumber, float chargeAmmountInMinutes)
        {
            ElectricEngine electricEngine = m_VechicleRecords[licenseNumber].Vehicle.Engine as ElectricEngine;
            electricEngine.ChargeBattery(chargeAmmountInMinutes / k_ParseMinuteToHours);
        }

        public object GetVehicleRecord(string licenseNumber)
        {
            throw new NotImplementedException();
        }

        public void FuelUpVehicle(string licenseNumber, float fuelAmmountToAdd, string fuelType)
        {
            FuelEngine fuelEngine = m_VechicleRecords[licenseNumber].Vehicle.Engine as FuelEngine;
            eFuelType fuelTypeParsedToEnum = (eFuelType)Enum.Parse(typeof(eFuelType), fuelType);
            fuelEngine.FillFuel(fuelAmmountToAdd, fuelTypeParsedToEnum);
        }
    }
}
