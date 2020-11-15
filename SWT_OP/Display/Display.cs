using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public class Display : IDisplay
    {
        private ITestDisplay _testDisplay;
        public Display(ITestDisplay testDisplay)
        {
            _testDisplay = testDisplay;
        }

        public void showConnectToPhone()
        {
            _testDisplay.WriteLine("Tilslut telefon");
        }
        public void showReadRFID()
        {
            _testDisplay.WriteLine("Indlæs RFID");
        }

        public void showConnectionToPhoneFailed()
        {
            _testDisplay.WriteLine("Tilslutningsfejl");
        }
        public void showChargerCabinetIsOccupied()
        {
            _testDisplay.WriteLine("Ladeskab optaget");
        }
        public void showRFIDMistake()
        {
            _testDisplay.WriteLine("RFID fejl");
        }
        public void showRemovePhone()
        {
            _testDisplay.WriteLine("Fjern telefon");
        }
        public void showChargeIsDone()
        {
            _testDisplay.WriteLine("Opladning er færdig");
        }
    }
}
