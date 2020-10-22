using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public interface IRFIDReader
    {
        event EventHandler<RFIDEventArgs> RfidEvent;
        void RfidDetect(int id);
       
    }
}
