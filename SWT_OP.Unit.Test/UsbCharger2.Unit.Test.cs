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
        private ConnectedEventArgs _connectedEventArgs;

        [SetUp]
        public void Setup()
        {
            _currentEventArgs = null;
            _connectedEventArgs = null;

            _uut = new UsbCharger();
            //_uut.UnlockedDoor();
            _uut.currentValueEvent +=
                (o, args) =>
                {
                    _currentEventArgs = args;
                };
            _uut.connectedValueEvent +=
                (o, args) =>
                {
                    _connectedEventArgs = args;
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

        [Test]
        public void IsConnected()
        {
            _uut.ConnectPhone();

            Assert.That(_connectedEventArgs.Connected, Is.EqualTo(true));
        }

        [Test]
        public void ISNOTConnected()
        {
            _uut.DisconnectPhone();

            Assert.That(_connectedEventArgs.Connected, Is.EqualTo(false));
        }
    }
}