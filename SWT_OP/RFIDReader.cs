using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public class RFIDReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RfidEvent;
        protected virtual void RfidDetectedEvent(RFIDEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }
        public void RfidDetected(int id)
        {
            RfidDetectedEvent(new RFIDEventArgs { RFID = id });
        }
    }
}
