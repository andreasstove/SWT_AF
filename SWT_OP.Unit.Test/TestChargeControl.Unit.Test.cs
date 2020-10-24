using NSubstitute;
using NUnit.Framework;


namespace SWT_OP.Unit.Test
{
    [TestFixture]
    public class TestChargeControl
    {
        private IUsbCharger _usbCharger;

        private ChargeControl _uut;

        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();

            _uut = new ChargeControl(_usbCharger);
        }

        //[TestCase(-100,false)]
        //[TestCase(0,false)]
        //[TestCase(100,true)]
        //[TestCase(200,true)]
        //[TestCase(500,true)]
        //public void testForCurrentLow(double current, bool set)
        //{
        //    _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });
        //    Assert.That(_uut.IsConnected, Is.EqualTo(set));
        //}

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

        //[Test]
        //public void TestToDisconnect()
        //{
            
        //}
       
    }
}
