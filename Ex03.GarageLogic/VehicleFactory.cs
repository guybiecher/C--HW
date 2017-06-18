using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{

    enum eCarTypeSupported
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

        public List<String> fieldsToFill = new List<String>()
        {
            "License Number",
            "Model",
            "Manufacturer",
            "AirPreasure",
            "EnergyLevel"
        };

        //public List<String> AdditionalDetails(string )


        public static Car CreateCar(
            string i_EngineType, string i_Color, string i_NumOfDoors,
            string i_Model, string i_LicenseNumber, float i_EnergyLevel, string i_Manufacturer, float i_AirPreasure)
        {
            List<Wheel> wheels = Car.CreateCarWheels(i_Manufacturer, i_AirPreasure);
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

        public static Motorcycle CreateMotorCycle(
            string i_EngineType ,string i_LicenseType,int i_EngineCC , string i_Model, string i_LicenseNumber,
            float i_EnergyLevel, string i_Manufacturer, float i_AirPreasure, float i_MaxAirPreasure)
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

        public static Truck CreateTruck(bool i_Toxic,float i_MaxWeight,string i_Model, string i_LicenseNumber,
            float i_EnergyLevel, string i_Manufacturer, float i_AirPreasure, float i_MaxAirPreasure)
        {
            List<Wheel> wheels = Car.CreateCarWheels(i_Manufacturer, i_AirPreasure);
            FuelEngine truckEngine = CreateFuelEngine(k_TruckCycleFuelCapacity, i_EnergyLevel, eFuelType.Octan96);
            return new Truck(i_Toxic,truckEngine, i_MaxWeight, i_Model, i_LicenseNumber, wheels);
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


    }
}
