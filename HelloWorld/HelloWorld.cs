using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DllTest;
using System.Configuration;

namespace HelloWorld
{
    class HelloWorld
    {
        public virtual void DisplayValue(string value)
        {            
            Console.WriteLine(value);
            //leave 5 seconds before closing
            Thread.Sleep(5000);
        }
    }
}
