using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    interface IDoor
    {
        public event EventHandler<DoorEventArgs> doorCloseEvent;
        public event EventHandler<DoorEventArgs> doorOpenEvent;
        public bool doorLocked { get; set; }
        public void LockedDoor();
        public void UnlockedDoor();
    }
}
