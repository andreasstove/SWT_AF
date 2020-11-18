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
        [TestCase(5.1)]
        [TestCase(500)]
        [TestCase(400)]
        public void HandleCurrentEvent_Called_showIsCharging(double current)
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = true });
            _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });
            _display.Received().showIsCharging();
        }
        [TestCase(500.1)]
        [TestCase(600)]
        public void HandleCurrentEvent_Called_showConnectionToPhoneFailed(double current)
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = true });
            _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });
            _display.Received().showConnectionToPhoneFailed();
        }
        [TestCase(0.1)]
        [TestCase(5)]
        [TestCase(1)]
        public void HandleCurrentEvent_Called_showChargeIsDone(double current)
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = true });
            _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });
            _display.Received().showChargeIsDone();
        }
        [Test]
        public void HandleCurrentEvent_Called_IsNotConnected()
        {
            _usbCharger.connectedValueEvent += Raise.EventWith(new ConnectedEventArgs { Connected = false });
            Assert.That(_uut.IsConnected, Is.False);
        }
    }
 

}

