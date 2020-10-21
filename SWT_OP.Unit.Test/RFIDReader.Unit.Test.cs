using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SWT_OP.Unit.Test
{
    [TestFixture]
    public class RFIDReaderTest
    {
        private RFIDEventArgs _rFIDEventArgs;
        private RFIDReader _uut;
        int id = 100;
        [SetUp]
        public void Setup()
        {
            _rFIDEventArgs = null;

            _uut = new RFIDReader();

            _uut.RfidDetected(id);

            _uut.RfidEvent +=
                (o, args) =>
                {
                    _rFIDEventArgs = args;
                };
        }
        [Test]
        public void RfidDetectedEvent()
        {
            int newId = 500;
            _uut.RfidDetected(newId);

            Assert.That(_rFIDEventArgs.RFID, Is.EqualTo(newId));
        }
    }
}
