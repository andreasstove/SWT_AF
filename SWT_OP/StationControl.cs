using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public class StationControl
    {
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };
        private LadeskabState _state;
        private IUsbCharger _charger;

        private readonly IDoor _door;
        private readonly IDisplay _display;
        private readonly IRFIDReader _RFIDReader;
        private int _oldId;

        private string logFile = "logfile.txt";

        public bool CurrentDoor { get; set;}
        public int CurrentRFIDReader { get; set; }
        
        StationControl(IDisplay display, IDoor door, IRFIDReader RFIDReader)
        {
            door.doorOpenEvent += HandleDoorOpenEvent;
            door.doorCloseEvent += HandleDoorCloseEvent;
            RFIDReader.RfidEvent += HandleRfidEvent;
        }
        private void HandleRfidEvent(object sender, RFIDEventArgs e)
        {
            CurrentRFIDReader = e.RFID;
        }
        private void HandleDoorOpenEvent(object sender, DoorEventArgs e )
        {
            CurrentDoor = e.Door;
            _state = LadeskabState.DoorOpen;
            _display.showConnectToPhone();
        }
        private void HandleDoorCloseEvent(object sender, DoorEventArgs e)
        {
            CurrentDoor = e.Door;
            _state = LadeskabState.Locked;
            _display.showReadRFID();
        }
        public void CheckId(int OldId, int id)
        {


        }
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _door.LockedDoor();
                        //_door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        //_door.UnlockDoor();
                        _door.UnlockedDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }


    }
}
