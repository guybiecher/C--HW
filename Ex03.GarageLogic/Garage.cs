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

        public void AddVehicle(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhoneNum, Vehicle i_Vehicle)
        {
            VechicleRecord vechicleRecord = new VechicleRecord(i_VehicleOwnerName, i_VehicleOwnerPhoneNum, eVehicleStatus.Repair, i_Vehicle);
            m_VechicleRecords.Add(i_LicenseNumber, vechicleRecord);
        }

        public List<string> GetAllLicenseNumbers(string filterByVechicleStatus)
        {

            //TODO: מחקתי את הפונקציה עם החתימה הריקה והורדתי את המשתנה הבוליאני שלך, אם אין פילטר אתה פשוט תקבל null
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

        public VechicleRecord GetVehicleRecord(string i_LicenseNumber)
        {
            throw new NotImplementedException();
        }

        public void FuelUpVehicle(string licenseNumber, float fuelAmmountToAdd, string fuelType)
        {
            FuelEngine fuelEngine = m_VechicleRecords[licenseNumber].Vehicle.Engine as FuelEngine;
            eFuelType fuelTypeParsedToEnum = (eFuelType)Enum.Parse(typeof(eFuelType), fuelType);
            fuelEngine.FillFuel(fuelAmmountToAdd, fuelTypeParsedToEnum);
        }

        public List<string> GetFieldsByVehicleType (string i_VehicleType)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSupportedVehiclesList()
        {
            throw new NotImplementedException();
        }
    }
}
