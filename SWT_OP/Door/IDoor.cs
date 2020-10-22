using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public interface IDoor
    {
        event EventHandler<DoorEventArgs> doorCloseEvent;
        event EventHandler<DoorEventArgs> doorOpenEvent;
        bool doorLocked { get; set; }
        void LockedDoor();
        void UnlockedDoor();
    }
}
