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
        private GarageLogic.Garage m_Garage;

        public GarageManager ()
        {
            this.m_ExitGarage = false;
            this.m_Garage = new GarageLogic.Garage();
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
            UI.ShowVehicleDetails(this.m_)
        }

        private void ChargeVehicle()
        {
            throw new NotImplementedException();
        }

        private void FuelVehicle()
        {
            throw new NotImplementedException();
        }

        private void InflateWeels()
        {
            throw new NotImplementedException();
        }

        private void ChangeCarStatus()
        {
            throw new NotImplementedException();
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
