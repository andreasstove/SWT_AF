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

        [Test]
        public void RfidTest()
        {

            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = 5 });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(5));
        }
        [Test]
        public void RfidDetected_doorLocked()
        {
            bool id = false;
            _charger.IsConnected = true;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = 5 });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(5));
        }

        [Test]
        public void RfidDected_doorOpenEvent()
        {
            bool id = false;
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = id });
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = 5 });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(5));

        }

    }
}
