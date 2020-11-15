using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public interface IDisplay
    {
        public void showConnectToPhone();
        public void showReadRFID();

        public void showConnectionToPhoneFailed();
        public void showChargerCabinetIsOccupied();
        public void showRFIDMistake();
        public void showRemovePhone();
        public void showChargeIsDone();
    }
}
