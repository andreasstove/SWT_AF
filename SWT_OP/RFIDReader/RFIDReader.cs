using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public class RFIDReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RfidEvent;
        public void RfidDetect(int id)
        {
            RfidDetectedEvent(new RFIDEventArgs { RFID = id });
        }
        protected virtual void RfidDetectedEvent(RFIDEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }
      
    }
}
