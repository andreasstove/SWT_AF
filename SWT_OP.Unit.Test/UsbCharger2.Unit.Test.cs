using NUnit.Framework;
using System;
using System.Threading;


namespace SWT_OP.Unit.Test
{
    [TestFixture]
    class UsbChargerTest
    {
      
        private UsbCharger _uut;
        private CurrentEventArgs _currentEventArgs;

        [SetUp]
        public void Setup()
        {
            _currentEventArgs = null;

            _uut = new UsbCharger();
            //_uut.UnlockedDoor();
            _uut.currentValueEvent +=
                (o, args) =>
                {
                    _currentEventArgs = args;
                };
        }


        [Test]
        public void StartCharge()
        {
            _uut.StartCharge();

            Assert.That(_currentEventArgs.Current, Is.EqualTo(500));
        }
        
        [Test]
        public void StopCharge()
        {
            _uut.StopCharge();

            Assert.That(_currentEventArgs.Current, Is.EqualTo(0));
        }
    }
}