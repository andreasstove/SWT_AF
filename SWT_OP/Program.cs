using System;

namespace SWT_OP
{
    class Program
    {
        static void Main(string[] args)
        {
            Door door = new Door();
            RFIDReader rFIDReader = new RFIDReader();
            TestDisplay testDisplay = new TestDisplay();
            Display display = new Display(testDisplay);
            UsbCharger usbCharger = new UsbCharger();
            ChargeControl charge = new ChargeControl(usbCharger, display);
            StationControl station = new StationControl(door, rFIDReader, display, charge);
            Console.WriteLine("Det hele er nu initiaseret og kan kører som program.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Prøver at sætte id op til scanneren");

            rFIDReader.RfidDetect(100);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Nu sættes telefonen  til før at RFI'en bruges");
            System.Threading.Thread.Sleep(1000);
            //prøv først at starte det uden´.
            usbCharger.ConnectPhone();

            rFIDReader.RfidDetect(110);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Nu prøves med det forkerete id at låse op og derefter det rigtige");

            System.Threading.Thread.Sleep(1000);
            rFIDReader.RfidDetect(120);

            System.Threading.Thread.Sleep(1000);
            rFIDReader.RfidDetect(110);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Nu åbnes døren for derefter at blive lukket");

            System.Threading.Thread.Sleep(1000);

            door.UnlockedDoor();
            System.Threading.Thread.Sleep(1000);
            door.LockedDoor();
            System.Threading.Thread.Sleep(1000);

        }
    }
}