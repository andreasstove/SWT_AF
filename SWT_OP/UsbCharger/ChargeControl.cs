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
            usbCharger.connectedValueEvent += HandleConnectionEvent;
            _usbCharger = usbCharger;
        }

        public void startCharge()
        {
            Console.WriteLine("Der lades nu");
            _usbCharger.StartCharge();
        }

        public void stopCharge()
        {
            Console.WriteLine("Der lades ikke længere");
            _usbCharger.StopCharge();
        }

        private void HandleCurrentEvent(object s, CurrentEventArgs e)
        {
            if (IsConnected != true)
            {
                Console.WriteLine("Der er ikke en telefon tilslutted");
            }
            else
            {
                if (e.Current == 0)
                {
                    Console.WriteLine("opladning er stoppet");
                }
                else
                {
                    Console.WriteLine("Opladning startet");
                }
            }
        }

        private void HandleConnectionEvent(object s, ConnectedEventArgs e)
        {
            
                IsConnected = e.Connected;
            
        }

    }
}
