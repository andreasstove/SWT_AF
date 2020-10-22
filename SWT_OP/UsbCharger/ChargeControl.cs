using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public class ChargeControl : IChargeControl
    {
        private readonly IUsbCharger _usbCharger;

        public bool IsConnected { get; set; }

        public ChargeControl(IUsbCharger usbCharger)
        {
            usbCharger.currentValueEvent += HandleCurrentEvent;
            _usbCharger = usbCharger;
        }

        public void startCharge()
        {
            Console.WriteLine("Der lades nu");
        }

        public void stopCharge()
        {
            Console.WriteLine("Der lades ikke længere");
        }

        private void HandleCurrentEvent(object s, CurrentEventArgs e)
        {
            if (e.Current == 0)
            {
                IsConnected = false;
            }
            else
            {
                IsConnected = true;
            }
        }

    }
}
