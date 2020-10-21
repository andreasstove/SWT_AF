using System;

namespace SWT_OP
{
    public class UsbCharger : IUsbCharger
    {
        public double CurrentValue { get; set; }
        public bool Connected { get; set; }

        public event EventHandler<CurrentEventArgs> currentValueEvent;

        protected virtual void CurrentValueDetectedEvent(CurrentEventArgs e)
        {
            currentValueEvent?.Invoke(this, e);
        }

        public void StartCharge()
        {
            CurrentValue = 500;
            CurrentValueDetectedEvent(new CurrentEventArgs { Current  = 500 });
            Console.WriteLine("Charge er startet");
        }

        public void StopCharge()
        {
            CurrentValue = 0;
            CurrentValueDetectedEvent(new CurrentEventArgs { Current = 0 });
            Console.WriteLine("Oplader ikke længere");
        }
    }
}
