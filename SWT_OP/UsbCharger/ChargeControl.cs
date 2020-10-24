using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SWT_OP
{
    public class ChargeControl : IChargeControl
    {
        private readonly IUsbCharger _usbCharger;

        public bool IsConnected { get; set; }
        public double Current { get; set; }

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
                    Current = e.Current;
                }
                else
                {
                    Console.WriteLine("Opladning er startet");
                    Current = e.Current;
                }
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

    }
}
