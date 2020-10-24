using System;

namespace SWT_OP
{
    public interface IUsbCharger
    {
        public event EventHandler<CurrentEventArgs> currentValueEvent;
        public event EventHandler<ConnectedEventArgs> connectedValueEvent;
        public double CurrentValue { get; set; }
        public bool Connectedbool { get; set; }
        public void StartCharge();
        public void StopCharge();

        public void ConnectPhone();
        public void DisconnectPhone();
    }
}
