using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public class Door : IDoor
    {
        public bool doorLocked { get; set; }

        public event EventHandler<DoorEventArgs> doorCloseEvent;
        public event EventHandler<DoorEventArgs> doorOpenEvent;

        public void LockedDoor()
        {
  
            if(!doorLocked)
            {
                DoorClose(new DoorEventArgs { Door = true });
                doorLocked = true;
            }
            //Console.WriteLine("Døren er lukket");
        }

        public void UnlockedDoor()
        {
            if (doorLocked)
            {
                DoorOpened(new DoorEventArgs { Door = false });
                doorLocked = false;
            }
            //Console.WriteLine("Døren er åben");
        }


        protected virtual void DoorOpened(DoorEventArgs e)
        {
            doorOpenEvent?.Invoke(this, e);
        }
        protected virtual void DoorClose(DoorEventArgs e)
        {
            doorCloseEvent?.Invoke(this,  e);
        }



    }
   
}
