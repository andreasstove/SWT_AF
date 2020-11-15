using System;
using System.Collections.Generic;
using System.Text;

namespace SWT_OP
{
    public class TestDisplay : ITestDisplay
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
