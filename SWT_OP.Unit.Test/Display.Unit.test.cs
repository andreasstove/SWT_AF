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
    public class TestDisplay
    {
        private IRFIDReader _rFIDReader;
        private IDoor _door;
        private IDisplay _display;

        private StationControl _uut;


        
        
        [SetUp]
        public void Setup()
        {
            //_display = Substitute.For<IDisplay>();
            _rFIDReader = Substitute.For<IRFIDReader>();
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _uut = new StationControl( _door, _rFIDReader);
            
        }

        [Test]
        public void Test()
        {
            /*_uut.CurrentDoor = false;
            _display.Received().showConnectToPhone();
            */
        }
       
        
    }
}
