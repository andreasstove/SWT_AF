using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    interface IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RfidEvent;
        public void RfidDetected(int id);
       
    }
}
