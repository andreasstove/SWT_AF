using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;


namespace SWT_OP.Unit.Test
{
    [TestFixture]
    public class TestStationControl
    { 
        private IRFIDReader _rFIDReader;
        private IDoor _door;
        private IDisplay _display;
        private IChargeControl _charger;

        private StationControl _uut;

        [SetUp]
        public void Setup()
        {
            _door = Substitute.For<IDoor>();
            _rFIDReader = Substitute.For<IRFIDReader>();
            _display = Substitute.For<IDisplay>();
            _charger = Substitute.For<IChargeControl>();

            _uut = new StationControl(_door, _rFIDReader, _display,_charger);

        }
        [TestCase(200)]
        [TestCase(-100)]
        [TestCase(0)]
        public void RFIDEventRaised_DifferentArguments_CurrentRFIDReaderIsCorrect(int id)
        {
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(id)); 
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DoorOpenEventRaised_booleanArguments_CurretDoorIsCorrect(bool id)
        {
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = id });
            Assert.That(_uut.CurrentDoor, Is.EqualTo(id));
        }
        [TestCase(true)]
        [TestCase(false)]
        public void DoorCloseEventRaised_booleanArguments_CurretDoorIsCorrect(bool id)
        {
            _door.doorCloseEvent += Raise.EventWith(new DoorEventArgs { Door = id });
            Assert.That(_uut.CurrentDoor, Is.EqualTo(id));
        }

        [TestCase(100)]
        [TestCase(-20)]

        public void RfidDetected_rfidEvent(int id)
        {

            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(id));
        }
        [TestCase(100)]
        [TestCase(-20)]
        public void TestRfidDetected_doorLocked_CurrectRFIDReaderIsCorrect(int id)
        {
            _charger.IsConnected = true;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(id));
        }

        [TestCase(100)]
        [TestCase(0)]
        [TestCase(-100)]
        public void TestRfidDected_doorOpenEvent_CurrentRFIDReaderIsCorrect(int id)
        {
            bool lockedDoor = true;
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = lockedDoor });
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(id));

        }

        [TestCase(100)]
        [TestCase(0)]
        [TestCase(-100)]
        public void TestRfidDected_doorOpenEvent_CurrectId(int id)
        {
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            Assert.That(_uut.CurrentDoor, Is.EqualTo(false));
        }

    
        [TestCase(100)]
        [TestCase(-20)]
        public void TestForRfidDetectionWithTwoIDsSame(int id)
        {
            _charger.IsConnected = true;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            _door.Received().UnlockedDoor();
        }

        [TestCase(100, 20)]
        [TestCase(-20, -19)]
        public void TestForRfidDetection_WithTwoIDsNotSame_(int id1, int id2)
        {
            _charger.IsConnected = true;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id1 });
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id2 });
            _door.Received().LockedDoor();
        }

        [Test]
        public void TestChargerNotON()
        {
            int id = 5;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            _door.DidNotReceive().LockedDoor();
        }

        [Test]
        public void TestDoorOpenedUnlock()
        {
            bool idDoor = true;
            int idRfid = 5;
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = idDoor });
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = idRfid });
            _door.DidNotReceive().LockedDoor();
        }

        [Test]
        public void TestDoorOpenedLock()
        {
            bool idDoor = true;
            int idRfid = 5;
            _charger.IsConnected = true;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = idRfid });
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = idDoor });
            _display.Received(1).showConnectToPhone();
        }



    }
}
