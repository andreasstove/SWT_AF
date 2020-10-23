using NUnit.Framework;
using System;
using System.Threading;


namespace SWT_OP.Unit.Test
{
    [TestFixture]
    class UsbChargerTest
    {
      
        private UsbCharger _uut;
        private UsbChargerEventArgs _receivedUsbChargerEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedUsbChargerEventArgs = null;

            _uut = new UsbCharger();
            //_uut.UnlockedDoor();
            _uut.CurrentValueDetectedEvent +=
                (o, args) =>
                {
                    _receivedUsbChargerEventArgs = args;
                }
        }


        [Test]
        public void StartCharge()
        {
            _uut.StartCharge();

            Assert.That(_receivedUsbChargerEventArgs.Current, Is.EqualTo(500));
        }
        //[Test]
        //public void StopCharge()
        //{
        //    _uut.LockedDoor();

        //    _uut.UnlockedDoor();

        //    Assert.That(_receivedDoorEventArgs.Door, Is.EqualTo(false));
        //}
    }
}