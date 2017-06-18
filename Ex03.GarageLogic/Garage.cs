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

        public void AddVehicle(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhoneNum, string i_VehicleStatus, Vehicle i_Vehicle)
        {
            eVehicleStatus vehicleStatusParsedToEnum = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_VehicleStatus);
            VechicleRecord vechicleRecord = new VechicleRecord(i_VehicleOwnerName, i_VehicleOwnerPhoneNum, vehicleStatusParsedToEnum, i_Vehicle);
            m_VechicleRecords.Add(i_LicenseNumber, vechicleRecord);
        }

        public List<string> GetAllLicenseNumbers(string filterByVechicleStatus)
        {

            bool useFilter = (filterByVechicleStatus == "NO FILTER") ? false : true;
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

        public void ChangeVehicleStatus(string i_LicenseNumber, string i_VechileNewStatus)
        {
            eVehicleStatus vechileNewStatusParsedToEnum = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_VechileNewStatus);
            m_VechicleRecords[i_LicenseNumber].VehicleStatus = vechileNewStatusParsedToEnum;
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            m_VechicleRecords[i_LicenseNumber].Vehicle.InflateWheelsToMax();
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_ChargeAmmountInMinutes)
        {
            ElectricEngine electricEngine = m_VechicleRecords[i_LicenseNumber].Vehicle.Engine as ElectricEngine;
            electricEngine.ChargeBattery(i_ChargeAmmountInMinutes / k_ParseMinuteToHours);
        }

        public string GetVehicleRecord(string i_LicenseNumber)
        {
            return m_VechicleRecords[i_LicenseNumber].ToString();
        }

        public void FuelUpVehicle(string licenseNumber, float fuelAmmountToAdd, string fuelType)
        {
            FuelEngine fuelEngine = m_VechicleRecords[licenseNumber].Vehicle.Engine as FuelEngine;
            eFuelType fuelTypeParsedToEnum = (eFuelType)Enum.Parse(typeof(eFuelType), fuelType);
            fuelEngine.FillFuel(fuelAmmountToAdd, fuelTypeParsedToEnum);
        }

        public Vehicle CreateVehicle(Dictionary<string, string> i_FieldsToFill, string i_VehicleType)
        {
            return VehicleFactory.CreateVehicle(i_FieldsToFill, i_VehicleType);
        }

        public List<String> GetVehicleList()
        {
            return VehicleFactory.GetVehicleType();
        }
    }
}
