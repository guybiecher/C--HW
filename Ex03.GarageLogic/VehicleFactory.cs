using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{

    enum eVehicleTypeSupported
    {
        Car = 1,
        Motorcycle = 2,
        Truck = 3
    }

    enum eEngineType
    {
        Electic = 1,
        Fuel = 2
    }

    class VehicleFactory
    {

        private const float k_CarFuelCapacity = 42f;
        private const float k_CarBatteryCapacity = 2.5f;
        private const float k_TruckCycleFuelCapacity = 135f;
        private const float k_MotorCycleFuelCapacity = 5.5f;
        private const float k_MotorCycleBatteryCapacity = 2.7f;

        private const string k_KeyLicenseNumber = "License Number";
        private const string k_KeyModel = "Model";
        private const string k_KeyWheelManufacturer = "Wheel Manufacturer";
        private const string k_KeyAirPreasure = "Air Preasure";
        private const string k_KeyEnergyLevel = "Energy Level";

        //Car and Motorcycle
        private const string k_EngineType = "Engine Type";
        
        //Car
        private const string k_KeyCarColor = "Color";
        private const string k_KeyCarNumberOfDoors = "Number Of Doors";

        //MotorCycle
        private const string k_KeyMotorCycleLicenseType = "License Type";
        private const string k_KeyMotorCycleEngineCC = "Engine CC";

        //Truck
        private const string k_KeyTruckIsToxic = "Is Toxic";
        private const string k_KeyTruckMaxWeight = "Max Weight";

        internal static List<String> GetVehicleType()
        {
            List<String> vehicleTypeSupported = new List<String>();
            foreach (eVehicleTypeSupported val in Enum.GetValues(typeof(eVehicleTypeSupported)))
            {
                vehicleTypeSupported.Add(val.ToString());
            }
            return vehicleTypeSupported;
        }

        public static List<String> GetFieldsToFill(string i_VehicleType)
        {
            eVehicleTypeSupported vehicleTypeSupported = ParseStringToVehicleTypeSupportedEnum(i_VehicleType);
            List<String> fieldsToFill = GetGenricFields();

            switch (vehicleTypeSupported)
            {
                case eVehicleTypeSupported.Car:
                    fieldsToFill.AddRange(GetCarAddationalFields());
                    break;
                case eVehicleTypeSupported.Motorcycle:
                    fieldsToFill.AddRange(GetMotorCycleAddationalFields());
                    break;
                case eVehicleTypeSupported.Truck:
                    fieldsToFill.AddRange(GetTruckAddationalFields());
                    break;
            }
            return fieldsToFill;
        }

        private static List<String> GetGenricFields()
        {
            return new List<String>()
                {
                    k_KeyLicenseNumber,
                    k_KeyModel,
                    k_KeyWheelManufacturer,
                    k_KeyAirPreasure,
                    k_KeyEnergyLevel
                };
        }

        private static List<String> GetCarAddationalFields()
        {
            return new List<String>()
                {
                    k_KeyCarColor,
                    k_KeyCarNumberOfDoors,
                    k_EngineType
                };
        }

        private static List<String> GetMotorCycleAddationalFields()
        {
            return new List<String>()
                {
                    k_EngineType,
                    k_KeyMotorCycleLicenseType,
                    k_KeyMotorCycleEngineCC
                };
        }

        private static List<String> GetTruckAddationalFields()
        {
            return new List<String>()
                {
                    k_KeyTruckIsToxic,
                    k_KeyTruckMaxWeight
                };
        }


        internal static Vehicle CreateVehicle(Dictionary<string,string> i_FieldsToFill,string i_VehicleType)
        {
            eVehicleTypeSupported vehicleTypeSupported = ParseStringToVehicleTypeSupportedEnum(i_VehicleType);

            string vehicleModel = GetKeyOrThrowExpection(i_FieldsToFill,k_KeyModel);
            string wheelManufacturer = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyWheelManufacturer);
            string airPreasure = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyAirPreasure);
            string energyLevel = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyEnergyLevel);
            string licenseNumber = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyLicenseNumber);

            Vehicle vehicle = null;
            switch (vehicleTypeSupported)
            {
                case eVehicleTypeSupported.Car:
                    string carColor = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyCarColor);
                    string numberOfDoors = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyCarNumberOfDoors);
                    string carEngineType = GetKeyOrThrowExpection(i_FieldsToFill, k_EngineType);

                    vehicle = CreateCar(carEngineType, carColor, numberOfDoors, vehicleModel, licenseNumber, float.Parse(energyLevel), wheelManufacturer, float.Parse(airPreasure));
                    break;

                case eVehicleTypeSupported.Motorcycle:
                    string licenseType = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyMotorCycleLicenseType);
                    string engineCC = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyMotorCycleEngineCC);
                    string motorCycleEngineType = GetKeyOrThrowExpection(i_FieldsToFill, k_EngineType);

                    vehicle = CreateMotorCycle(motorCycleEngineType, licenseType, float.Parse(engineCC), vehicleModel, licenseNumber, float.Parse(energyLevel), wheelManufacturer, float.Parse(airPreasure));
                    break;

                case eVehicleTypeSupported.Truck:
                    string isToxic = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyTruckIsToxic);
                    string maxWeight = GetKeyOrThrowExpection(i_FieldsToFill, k_KeyTruckMaxWeight);

                    vehicle = CreateTruck(bool.Parse(isToxic), float.Parse(maxWeight), vehicleModel, licenseNumber, float.Parse(energyLevel), wheelManufacturer, float.Parse(airPreasure));
                    break;
            }
            return vehicle;


        }

        private static string GetKeyOrThrowExpection(Dictionary<string, string> i_FieldsToFill , string key)
        {
            bool isSuccessParsed = i_FieldsToFill.TryGetValue(key, out string value);

            if (isSuccessParsed)
            {
                return value;
            }
            else
            {
                throw new ArgumentException(String.Format("Can't find key {0}", key));
            }

        }

        private static Car CreateCar(
            string i_EngineType, string i_Color, string i_NumOfDoors,
            string i_Model, string i_LicenseNumber, float i_EnergyLevel, string i_WheelManufacturer, float i_AirPreasure)
        {
            List<Wheel> wheels = Car.CreateCarWheels(i_WheelManufacturer, i_AirPreasure);
            Engine carEngine = null;

            eEngineType engineTypeParsedToEnum = ParseStringToEngineTypeEnum(i_EngineType);
            switch (engineTypeParsedToEnum)
            {
                case eEngineType.Electic:
                    carEngine = CreateElectricEngine(k_CarBatteryCapacity, i_EnergyLevel);
                    break;

                case eEngineType.Fuel:
                    carEngine = CreateFuelEngine(k_CarFuelCapacity, i_EnergyLevel, eFuelType.Octan98);
                    break;
            }
            return new Car(ParseStringToColorTypeEnum(i_Color), carEngine, ParseStringToNumberOfDoorsTypeEnum(i_NumOfDoors), i_Model, i_LicenseNumber, wheels);
        }

        private static Motorcycle CreateMotorCycle(
            string i_EngineType, string i_LicenseType, float i_EngineCC, string i_Model, string i_LicenseNumber,
            float i_EnergyLevel, string i_Manufacturer, float i_AirPreasure)
        {
            List<Wheel> wheels = Car.CreateCarWheels(i_Manufacturer, i_AirPreasure);
            Engine motorcycleEngine = null;
            eEngineType engineTypeParsedToEnum = ParseStringToEngineTypeEnum(i_EngineType);

            switch (engineTypeParsedToEnum)
            {
                case eEngineType.Electic:
                    motorcycleEngine = CreateElectricEngine(k_MotorCycleBatteryCapacity, i_EnergyLevel);
                    break;

                case eEngineType.Fuel:
                    motorcycleEngine = CreateFuelEngine(k_MotorCycleFuelCapacity, i_EnergyLevel, eFuelType.Octan95);
                    break;
            }
            return new Motorcycle(ParseStringToLicenseTypeEnum(i_LicenseType), motorcycleEngine, i_EngineCC, i_Model, i_LicenseNumber, wheels);
        }

        private static Truck CreateTruck(bool i_Toxic, float i_MaxWeight, string i_Model, string i_LicenseNumber,
            float i_EnergyLevel, string i_Manufacturer, float i_AirPreasure)
        {
            List<Wheel> wheels = Car.CreateCarWheels(i_Manufacturer, i_AirPreasure);
            FuelEngine truckEngine = CreateFuelEngine(k_TruckCycleFuelCapacity, i_EnergyLevel, eFuelType.Octan96);
            return new Truck(i_Toxic, truckEngine, i_MaxWeight, i_Model, i_LicenseNumber, wheels);
        }

        private static FuelEngine CreateFuelEngine(float i_MaxFuelTank, float i_CurrentFuelTank, eFuelType i_FuelType)
        {
            return new FuelEngine(i_FuelType, i_CurrentFuelTank, i_MaxFuelTank);
        }

        private static ElectricEngine CreateElectricEngine(float i_MaxEnergyLevel, float i_CurrentBatteryLevel)
        {
            return new ElectricEngine(i_CurrentBatteryLevel, i_MaxEnergyLevel);
        }

        private static eEngineType ParseStringToEngineTypeEnum(string i_EngineType)
        {
            return (eEngineType)Enum.Parse(typeof(eEngineType), i_EngineType);
        }

        private static eCarColor ParseStringToColorTypeEnum(string i_CarColor)
        {
            return (eCarColor)Enum.Parse(typeof(eCarColor), i_CarColor);
        }

        private static eNumberOfDoors ParseStringToNumberOfDoorsTypeEnum(string i_NumberOfDoors)
        {
            return (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_NumberOfDoors);
        }

        private static eLicenseType ParseStringToLicenseTypeEnum(string i_LicenseType)
        {
            return (eLicenseType)Enum.Parse(typeof(eLicenseType), i_LicenseType);
        }

        private static eVehicleTypeSupported ParseStringToVehicleTypeSupportedEnum(string i_VehicleTypeSupported)
        {
            return (eVehicleTypeSupported)Enum.Parse(typeof(eVehicleTypeSupported), i_VehicleTypeSupported);
        }


    }
}
