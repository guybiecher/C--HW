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

        public void AddVehicleRecord(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhoneNum, Dictionary<string, string> i_FieldsToFill, string i_VehicleType)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_FieldsToFill, i_VehicleType, i_LicenseNumber);
            VechicleRecord vechicleRecord = new VechicleRecord(i_VehicleOwnerName, i_VehicleOwnerPhoneNum, eVehicleStatus.Repair, vehicle);
            m_VechicleRecords.Add(i_LicenseNumber, vechicleRecord);
        }

        public List<string> GetAllLicenseNumbers(string filterByVechicleStatus)
        {

            bool useFilter = (filterByVechicleStatus == "NO FILTER") ? false : true;

            List<string> allCarsLicenseNumbers = new List<string>();
            foreach (KeyValuePair<string, VechicleRecord> vechicle in m_VechicleRecords)
            {
                if (!useFilter || vechicle.Value.VehicleStatus.ToString().Equals(filterByVechicleStatus))
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
            if (m_VechicleRecords[i_LicenseNumber].Vehicle.Engine is ElectricEngine)
            {
                ElectricEngine electricEngine = m_VechicleRecords[i_LicenseNumber].Vehicle.Engine as ElectricEngine;
                electricEngine.ChargeBattery(i_ChargeAmmountInMinutes / k_ParseMinuteToHours);
            }
            else
            {
                throw new ArgumentException("Trying to charge vechicle with fuel engine");
            }
        }

        public VechicleRecord GetVehicleRecord(string i_LicenseNumber)
        {
            return m_VechicleRecords[i_LicenseNumber];
        }

        public void FuelUpVehicle(string i_LicenseNumber, float fuelAmmountToAdd, string fuelType)
        {
            if (m_VechicleRecords[i_LicenseNumber].Vehicle.Engine is FuelEngine)
            {
                FuelEngine fuelEngine = m_VechicleRecords[i_LicenseNumber].Vehicle.Engine as FuelEngine;
                eFuelType fuelTypeParsedToEnum = (eFuelType)Enum.Parse(typeof(eFuelType), fuelType);
                fuelEngine.FillFuel(fuelAmmountToAdd, fuelTypeParsedToEnum);
            }
            else
            {
                throw new ArgumentException("Trying to fuel up vehicle with electric engine ");
            }
        }

        public List<String> GetSupportedVehiclesList()
        {
            return VehicleFactory.GetVehicleType();
        }

        public List<string> GetFieldsByVehicleType(string i_VehicleType)
        {
            return VehicleFactory.GetFieldsToFill(i_VehicleType);
        }
    }
}
