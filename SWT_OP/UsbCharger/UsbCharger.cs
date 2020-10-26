﻿using System;

namespace SWT_OP
{
    public class UsbCharger : IUsbCharger
    {
        public double CurrentValue { get; set; }
        public bool Connectedbool { get; set; }

        public event EventHandler<CurrentEventArgs> currentValueEvent;
        public event EventHandler<ConnectedEventArgs> connectedValueEvent;

        protected virtual void CurrentValueDetectedEvent(CurrentEventArgs e)
        {
            currentValueEvent?.Invoke(this, e);
        }

        protected virtual void ConnectedDetectedEvent(ConnectedEventArgs e)
        {
            connectedValueEvent?.Invoke(this, e);
        }

       


        public void StartCharge()
        {
            CurrentValue = 500;
            CurrentValueDetectedEvent(new CurrentEventArgs { Current  = CurrentValue });
            //Console.WriteLine("Charge er startet");
        }

        public void StopCharge()
        {
            CurrentValue = 0;
            CurrentValueDetectedEvent(new CurrentEventArgs { Current = CurrentValue });
            //Console.WriteLine("Oplader ikke længere");
        }
        
        public void ConnectPhone()
        {
            Connectedbool = true;
            ConnectedDetectedEvent(new ConnectedEventArgs { Connected = Connectedbool });
            //Console.WriteLine("telefonen er nu forbundet");

        }

        public void DisconnectPhone()
        {
            Connectedbool = false;
            ConnectedDetectedEvent(new ConnectedEventArgs { Connected = Connectedbool });
            //Console.WriteLine("Telefonen er ikke forbundet længere");
        }
    }
}
