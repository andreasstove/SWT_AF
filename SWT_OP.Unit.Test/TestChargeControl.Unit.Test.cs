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

        [TestCase(-100,false)]
        [TestCase(0,false)]
        [TestCase(100,true)]
        [TestCase(200,true)]
        [TestCase(500,true)]
        public void testForCurrentLow(double current, bool set)
        {
            _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current });
            Assert.That(_uut.IsConnected, Is.EqualTo(set));
        }

       
    }
}
