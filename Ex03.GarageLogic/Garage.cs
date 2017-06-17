using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private static Dictionary<string, VechicleRecord> m_VechicleRecords = new Dictionary<string, VechicleRecord>();

 
        public static bool IsVehicleListed(string i_LicenseNumber)
        {
            return m_VechicleRecords.ContainsKey(i_LicenseNumber);
        }

        public static List<string> getAllLicenseNumbers(eVehicleStatus filterByVechicleStatus ,bool i_UseFilter)
        {
           List<string> allCarsLicenseNumbers = new List<string>(); 
           foreach (KeyValuePair<string, VechicleRecord> vechicle in m_VechicleRecords)
            {
                if (!i_UseFilter || vechicle.Value.VehicleStatus.Equals(filterByVechicleStatus))
                {
                    allCarsLicenseNumbers.Add(vechicle.Key);
                }
            }
            return allCarsLicenseNumbers;
        }

        public static void ChangeCarStatus(string i_LicenseNumber, eVehicleStatus i_VechileNewStatus)
        {
            m_VechicleRecords[i_LicenseNumber].VehicleStatus = i_VechileNewStatus;
        }

        public static void ChangeCarStatus(string i_LicenseNumber, eVehicleStatus i_VechileNewStatus)
        {
            m_VechicleRecords[i_LicenseNumber].VehicleStatus = i_VechileNewStatus;
        }

        public static void InflateWheelsToMax(string i_LicenseNumber)
        {
            //m_VechicleRecords[i_LicenseNumber].Vehicle.
        }


    }
}
