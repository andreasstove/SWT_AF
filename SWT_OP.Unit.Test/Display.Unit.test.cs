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
            _uut = new StationControl( _door, _rFIDReader, _display,_charger);
            
        }

        [Test]
        public void Test()
        {   
            bool id = true;
            _door.doorOpenEvent += Raise.EventWith(new DoorEventArgs { Door = id });
            _display.Received().showConnectToPhone();
        }

        [Test]
        public void Test2()
        {
            bool id = false;
            _door.doorCloseEvent += Raise.EventWith(new DoorEventArgs { Door = id });
            _display.Received().showReadRFID();
        }

        [Test]
        public void Test3()
        {
            int id = 2;
            _rFIDReader.RfidEvent += Raise.EventWith(new RFIDEventArgs { RFID = id });
            _display.Received().showConnectToPhone();
        }

        
    }
}
