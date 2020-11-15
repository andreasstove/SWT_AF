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
        public void ShowConnectToPhone_Called_WriteLine()
        {
            _text = "Tilslut telefon";
            _uut.showConnectToPhone();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowReadRFID_Called_WriteLine()
        {
            _text = "Indlæs RFID";
            _uut.showReadRFID();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowConnectionToPhoneFailed_Called_WriteLine()
        {
            _text = "Tilslutningsfejl";
            _uut.showConnectionToPhoneFailed();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowChargerCabinetIsOccupied_Called_WriteLine()
        {
            _text = "Ladeskab optaget";
            _uut.showChargerCabinetIsOccupied();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowRFIDMistake_Called_WriteLine()
        {
            _text = "RFID fejl";
            _uut.showRFIDMistake();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowRemovePhone_Called_WriteLine()
        {
            _text = "Fjern telefon";
            _uut.showRemovePhone();
            _testDisplay.Received(1).WriteLine(_text);
        }
        [Test]
        public void ShowChargeIsDone_Called_WriteLine()
        {
            _text = "Opladning er færdig";
            _uut.showChargeIsDone();
            _testDisplay.Received(1).WriteLine(_text);
        }
    }
}
