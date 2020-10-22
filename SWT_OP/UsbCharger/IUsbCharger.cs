using System;

namespace SWT_OP
{
    public interface IUsbCharger
    {
        public event EventHandler<CurrentEventArgs> currentValueEvent;
        public double CurrentValue { get; set; }
        public bool Connected { get; set; }
        public void StartCharge();
        public void StopCharge();
    }
}
