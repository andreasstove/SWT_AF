using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public class ChargeControl : IChargeControl
    {
        public bool IsConnected { get; set; }
        public void startCharge()
        {

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
