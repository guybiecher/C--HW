using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class GarageManager
    {
        private bool m_ExitGarage;
        private Garage m_Garage;

        public GarageManager ()
        {
            this.m_ExitGarage = false;
            this.m_Garage = new Garage();
        }

        public void start ()
        {
            UI.Initiate();
            UI.ShowGarageActions();
            while (!m_ExitGarage)
            {
                string userAction = UI.GetUserActionInput();
                manageAction(userAction);
            }
        }

        private void manageAction(string i_UserAction)
        {
            switch (i_UserAction)
            {
                case "1":
                    CarCheckIn();
                    break;
                case "2":
                    ShowRegisteredVehicles();
                    break;
                case "3":
                    ChangeCarStatus();
                    break;
                case "4":
                    InflateWeels();
                    break;
                case "5":
                    FuelVehicle();
                    break;
                case "6":
                    ChargeVehicle();
                    break;
                case "7":
                    ShowVehicleDetails();
                    break;
                case "8":
                    ExitGarage();
                    break;
            }   
        }

        private void ExitGarage()
        {
            this.m_ExitGarage = true;
        }

        private void ShowVehicleDetails()
        {
            string licenseNumber = UI.GetLicenseNumberInput();
            bool isVehicleListed = m_Garage.IsVehicleListed(licenseNumber);

            if (isVehicleListed)
            {
                UI.ShowVehicleDetails(m_Garage.GetVehicleRecord(licenseNumber));
            }
            else
            {
                UI.NoRecordFound();
            }
        }

        private void ChargeVehicle()
        {
            string licenseNumber = UI.GetLicenseNumberInput();
            float chargeAmmountInMinutes = UI.GetChargeAmmountInput();
            bool isVehicleListed = m_Garage.IsVehicleListed(licenseNumber);

            if (isVehicleListed)
            {
                try
                {
                    m_Garage.ChargeVehicle(licenseNumber, chargeAmmountInMinutes);
                } catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                    ChargeVehicle();
                }
            }
            else
            {
                UI.NoRecordFound();
            }
        }

        private void FuelVehicle()
        {
            string licenseNumber = UI.GetLicenseNumberInput();
            string fuelType = UI.GetFuelTypeInput();
            float fuelAmmountToAdd = UI.GetFuelAmmountInput();
            bool isVehicleListed = m_Garage.IsVehicleListed(licenseNumber);

            if (isVehicleListed)
            {
                try
                {
                    m_Garage.FuelUpVehicle(licenseNumber, fuelAmmountToAdd, fuelType);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                    FuelVehicle();
                } catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                    FuelVehicle();
                }
            }
            else
            {
                UI.NoRecordFound();
            }
        }

        private void InflateWeels()
        {
            string licenseNumber = UI.GetLicenseNumberInput();
            bool isVehicleListed = m_Garage.IsVehicleListed(licenseNumber);

            if (isVehicleListed)
            {
                m_Garage.InflateWheelsToMax();
            }
            else
            {
                UI.NoRecordFound();
            }
        }

        private void ChangeVehicleStatus()
        {
            string licenseNumber = UI.GetLicenseNumberInput();
            string vehicleState = UI.GetVehicleStateInput();
            bool isVehicleListed = m_Garage.IsVehicleListed(licenseNumber);

            if (isVehicleListed)
            {
                try
                {
                    m_Garage.ChangeVehicleStatus(licenseNumber, vehicleState);
                } catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                    ChangeVehicleStatus();
                }
            }
            else
            {
                UI.NoRecordFound();
            }
        }

        private void ShowRegisteredVehicles()
        {
            throw new NotImplementedException();
        }

        private void CarCheckIn()
        {

        }
    }
}
