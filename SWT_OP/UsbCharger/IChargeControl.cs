using System;

namespace SWT_OP
{
    public interface IChargeControl
    {     
        public void startCharge();
        public void stopCharge();
        public bool IsConnected { get; set; }

    }
   
}
