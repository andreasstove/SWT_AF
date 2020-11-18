using System;
using SWT_OP;

namespace ConsoleApp
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
            Console.WriteLine("Det hele er nu initialiseret og kan køre som program.");
            System.Threading.Thread.Sleep(5000);
            
            Console.WriteLine("Prøver at sætte id op til scanneren");
            System.Threading.Thread.Sleep(2000);
            rFIDReader.RfidDetect(100);
            System.Threading.Thread.Sleep(5000);
            
            Console.WriteLine("Nu sættes telefonen til for at RFI'en bruges");
            System.Threading.Thread.Sleep(5000);
            //prøv først at starte det uden´.
            usbCharger.ConnectPhone();
            rFIDReader.RfidDetect(110);
            System.Threading.Thread.Sleep(5000);
            
            Console.WriteLine("Nu prøves med det forkerete id for at låse op og derefter prøves med det rigtige id");
            System.Threading.Thread.Sleep(5000);
            rFIDReader.RfidDetect(120);

            System.Threading.Thread.Sleep(5000);
            rFIDReader.RfidDetect(110);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Nu åbnes døren for derefter at blive lukket");

            System.Threading.Thread.Sleep(5000);

            door.UnlockedDoor();
            System.Threading.Thread.Sleep(5000);
            door.LockedDoor();
            System.Threading.Thread.Sleep(10000);

            Console.WriteLine("Nu låses døren, og så prøver vi at åbne den");
            rFIDReader.RfidDetect(130);
            System.Threading.Thread.Sleep(10000);
            charge.IsConnected = true;
            door.UnlockedDoor();

        }
    }
}
