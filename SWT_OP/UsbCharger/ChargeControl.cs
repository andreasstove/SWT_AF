using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SWT_OP
{
    public class ChargeControl : IChargeControl
    {
        private readonly IUsbCharger _usbCharger;
        private readonly IDisplay _display;

       

        public bool IsConnected { get; set; }
        public double Current { get; set; }
        

        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {

            _display = display;
            _usbCharger = usbCharger;

            usbCharger.connectedValueEvent += HandleConnectionEvent;
            usbCharger.currentValueEvent += HandleCurrentEvent;
        }

        public void startCharge()
        {
            _usbCharger.StartCharge();
        }

        public void stopCharge()
        {
            _usbCharger.StopCharge();
        }



        private void HandleCurrent(double current)
        {
            switch(current)
            {
                case double n when (0 < n && n <= 5):
                    _usbCharger.StopCharge();
                    _display.showChargeIsDone();
                    break;
                case double n when (5 < n && n <= 500):
                    _display.showIsCharging();
                    break;
                case double n when (500 < n):
                    _usbCharger.StopCharge();
                    _display.showConnectionToPhoneFailed();
                    break;  
            }
        }

        private void HandleConnectionEvent(object s, ConnectedEventArgs e)
        { 
            IsConnected = e.Connected;
            if (IsConnected == false)
            {
                Current = 0;
            }
            
            
        }
        private void HandleCurrentEvent(object s, CurrentEventArgs e)
        {
            HandleCurrent(e.Current);
        }
    }
}
