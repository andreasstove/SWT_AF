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

        private bool _overload;
        private bool _charging;
        private System.Timers.Timer _timer;
        private int _ticksSinceStart;

        public double CurrentValue { get; set; }
        public bool Connected { get; set; }

        public event EventHandler<CurrentEventArgs> CurrentValueEvent;
        public event EventHandler<ConnectedEventArgs> connectedValueEvent;


        protected virtual void CurrentValueDetectedEvent(CurrentEventArgs e)
        {
            currentValueEvent?.Invoke(this, e);
        }

        protected virtual void ConnectedDetectedEvent(ConnectedEventArgs e)
        {
            connectedValueEvent?.Invoke(this, e);
        }
        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            // Only execute if charging
            if (_charging)
            {
                _ticksSinceStart++;
                if (Connected && !_overload)
                {
                    double newValue = MaxCurrent -
                                      _ticksSinceStart * (MaxCurrent - FullyChargedCurrent) / (ChargeTimeMinutes * 60 * 1000 / CurrentTickInterval);
                    CurrentValue = Math.Max(newValue, FullyChargedCurrent);
                }
                else if (Connected && _overload)
                {
                    CurrentValue = OverloadCurrent;
                }
                else if (!Connected)
                {
                    CurrentValue = 0.0;
                }

                OnNewCurrent();
            }
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
        private void OnNewCurrent()
        {
            CurrentValueEvent?.Invoke(this, new CurrentEventArgs() { Current = this.CurrentValue });
        }
    }
}
