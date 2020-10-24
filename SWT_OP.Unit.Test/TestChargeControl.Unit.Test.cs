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

        [Test]
        public void testForCurrentLow()
        {
            _usbCharger.currentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = 200 });
            Assert.That(_uut.IsConnected, Is.EqualTo(true));
        }

       
    }
}
