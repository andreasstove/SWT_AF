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

        private StationControl _uut;

        [SetUp]
        public void Setup()
        {
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
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            Assert.That(_uut.CurrentRFIDReader, Is.EqualTo(id)); 
        }
        [TestCase(true)]
        [TestCase(false)]
        public void doorOpenEventRaised_booleanArguments_CurretDoorIsCorrect(bool id)
        {
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = id });
            Assert.That(_uut.CurrentDoor, Is.EqualTo(id));
        }

    }
}
