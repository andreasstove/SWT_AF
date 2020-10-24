using System;

namespace SWT_OP
{
    public class CurrentEventArgs : EventArgs
    {
        public double Current { get; set; }
    }

    public class ConnectedEventArgs : EventArgs
    {
        public bool Connected { get; set; }
    }
}
