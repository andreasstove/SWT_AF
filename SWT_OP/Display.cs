using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public class Display : IDisplay
    {

        public void showConnectToPhone()
        {
            Console.WriteLine("Tilslut telefon");
        }
        public void showReadRFID()
        {
            Console.WriteLine("Indlæs RFID");
        }

        public void showConnectionToPhoneFailed()
        {
            Console.WriteLine("Tilslutningsfejl");

        }
        public void showChargerCabinetIsOccupied()
        {
            Console.WriteLine("Ladeskab optaget");
        }
        public void showRFIDMistake()
        {
            Console.WriteLine("RFID fejl");
        }
        public void showRemovePhone()
        {
            Console.WriteLine("Fjern telefon");
        }

    }
}
