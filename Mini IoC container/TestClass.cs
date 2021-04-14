using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_IoC_container
{
    class TestClass : IRight
    {
        public TestClass()
        {

        }

        public void Message()
        {
            Console.WriteLine("Success");
        }
    }
}
