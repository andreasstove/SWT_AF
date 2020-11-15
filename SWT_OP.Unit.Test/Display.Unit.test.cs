using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
namespace SWT_OP.Unit.Test
{
    [TestFixture]
    class TestDisplay
    {
        private ITestDisplay _testDisplay;
        private Display _uut;
        private string _text;

        [SetUp]
        public void Setup()
        {
            _testDisplay = Substitute.For<ITestDisplay>();
            _uut = new Display(_testDisplay);
        }

        [Test]
        public void ShowConnectToPhone_test()
        {
            _text = "Tilslut telefon";
            _uut.showConnectToPhone();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowReadRFID_test()
        {
            _text = "Indlæs RFID";
            _uut.showReadRFID();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowConnectionToPhoneFailed_test()
        {
            _text = "Tilslutningsfejl";
            _uut.showConnectionToPhoneFailed();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowChargerCabinetIsOccupied_test()
        {
            _text = "Ladeskab optaget";
            _uut.showChargerCabinetIsOccupied();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowRFIDMistake_test()
        {
            _text = "RFID fejl";
            _uut.showRFIDMistake();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowRemovePhone_test()
        {

            _text = "Fjern telefon";
            _uut.showRemovePhone();
            _testDisplay.Received(1).WriteLine(_text);
        }

    }
}
