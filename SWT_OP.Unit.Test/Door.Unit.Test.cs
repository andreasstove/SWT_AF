using NUnit.Framework;
using System;
using System.Threading;


namespace SWT_OP.Unit.Test
{
    [TestFixture]
    class DoorTest
    {
        private DoorEventArgs _receivedDoorEventArgs;
        private Door _uut;

        [SetUp]
        public void Setup()
        {
            _receivedDoorEventArgs = null;

            _uut = new Door();
            _uut.UnlockedDoor();

            _uut.doorCloseEvent +=
                (o, args) =>
                {
                    _receivedDoorEventArgs = args;
                };
            _uut.doorOpenEvent +=
                (o, args) =>
                {
                    _receivedDoorEventArgs = args;
                };
        }

 
        [Test]
        public void Doorlocked()
        {
            _uut.LockedDoor();

            Assert.That(_receivedDoorEventArgs.Door, Is.EqualTo(true));
        }
        [Test]
        public void DoorUnlocked()
        {
            _uut.LockedDoor();

            _uut.UnlockedDoor();

            Assert.That(_receivedDoorEventArgs.Door, Is.EqualTo(false));
        }
    }
}