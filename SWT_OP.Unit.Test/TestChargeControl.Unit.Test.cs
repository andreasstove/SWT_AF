using NSubstitute;
using NUnit.Framework;


namespace SWT_OP.Unit.Test
{
    [TestFixture]
    public class TestChargeControl
    {
        private IUsbCharger _usbCharger;
        private ITestDisplay _testDisplay;
        private ChargeControl _uut;
        private IDisplay _display;

        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _testDisplay = Substitute.For<ITestDisplay>();
            _display = Substitute.For <IDisplay>();

            _uut = new ChargeControl(_usbCharger, _display);
        }
/*
        [TestCase(-100, false)]
        [TestCase(0, false)]
        [TestCase(100, true)]
        [TestCase(200, true)]
        [TestCase(500, true)]
        public void testForCurrentLow(double current, bool set)
        {
            _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });
            Assert.That(_uut.IsConnected, Is.EqualTo(set));
        }
*/
        [TestCase(false)]
        [TestCase(true)]
        public void TestToConnection(bool connection)
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = connection });
            Assert.That(_uut.IsConnected, Is.EqualTo(connection));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void TestToConnectionDouble(bool connection)
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = connection });
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = connection });
            Assert.That(_uut.IsConnected, Is.EqualTo(connection));
        }

        [TestCase(false,true)]
        [TestCase(true,false)]
        public void TestToConnectionChange(bool connection, bool nextConnection)
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = connection });
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = nextConnection });
            Assert.That(_uut.IsConnected, Is.EqualTo(nextConnection));
        }

        [Test]
        public void TestStartCharge()
        {
            _uut.startCharge();
            _usbCharger.Received(1).StartCharge();
        }

        [Test]
        public void StopCharge()
        {
            _uut.stopCharge();
            _usbCharger.Received(1).StopCharge();
        }

        [TestCase(false,500,0)]
        [TestCase(false,0,0)]
        [TestCase(true,500,500)]
        [TestCase(true,0,0)]
        public void TestForConnectionAndCurrent(bool connection, double sendCurrent, double recvCurrent)
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = connection });
            _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = sendCurrent });
            Assert.That(_uut.Current, Is.EqualTo(recvCurrent));
        
        }


    }
}
