using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
namespace SWT_OP.Unit.Test
{
    [TestFixture]
    class TestDisplay
    {
        private IRFIDReader _rFIDReader;
        private IDoor _door;
        private IDisplay _display;
        private IChargeControl _charger;

        private StationControl _uut;




        [SetUp]
        public void Setup()
        {
            _rFIDReader = Substitute.For<IRFIDReader>();
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _charger = Substitute.For<IChargeControl>();
            _uut = new StationControl(_door, _rFIDReader, _display, _charger);

        }

        [Test]
        public void ShowConnectionWithDoorEvent()
        {
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = true });
            _display.Received().showConnectToPhone();
        }

        [Test]
        public void ShowRFID()
        {
            _door.doorCloseEvent += Raise.EventWith(new DoorEventArgs { Door = false });
            _display.Received().showReadRFID();
        }

        [Test]
        public void ShowConnection()
        {
            _charger.IsConnected = true;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = 8 });
            _display.Received().showConnectToPhone();
        }

        [Test]
        public void ShowFailConnection()
        {
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = 3 });
            _display.Received().showConnectionToPhoneFailed();
        }

        //[Test]
        //public void et
        //{

        //}
        
    }
}
