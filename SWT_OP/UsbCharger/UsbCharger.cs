using System;
using System.Timers;

namespace SWT_OP
{
    public class UsbCharger : IUsbCharger
    {
        // Constants
        private const double MaxCurrent = 500.0; // mA
        private const double FullyChargedCurrent = 2.5; // mA
        private const double OverloadCurrent = 750; // mA
        private const int ChargeTimeMinutes = 20; // minutes
        private const int CurrentTickInterval = 250; // ms


        public double CurrentValue { get; set; }
        public bool Connected { get; set; }
        public bool Connectedbool { get; private set; }

        public event EventHandler<ConnectedEventArgs> connectedValueEvent;
        public event EventHandler<CurrentEventArgs> currentValueEvent;

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
