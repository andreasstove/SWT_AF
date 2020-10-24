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
        private IUsbCharger _usbCharger;
        private StationControl _uut;

        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _door = Substitute.For<IDoor>();
            _rFIDReader = Substitute.For<IRFIDReader>();
            _display = Substitute.For<IDisplay>();
            _uut = new StationControl(_door, _rFIDReader, _display);

        }
        [TestCase(200)]
        [TestCase(-100)]
        [TestCase(0)]
        public void RFIDEventRaised_DifferentArguments_CurrentRFIDReaderIsCorrect(int id)
        {
            _usbCharger.Connectedbool = true;
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

       [Test]
       public void RFIDDetected_test_IsCorrect()
        {
            int id = 100;
            bool check = false;
            _usbCharger.Connectedbool = true;
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = check });
            _uut.RfidDetected(id);
            Assert.That(_door.doorLocked, Is.EqualTo(check));
        }
    }
}
