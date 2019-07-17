using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DllTest;
using System.Configuration;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            DllHW dll = new DllHW();
            string value = dll.GetValue();

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["WriteToDatabase"]))
            {
                // display value and also save the value into database table
                HelloWorldUseAPI hwuapi = new HelloWorldUseAPI();                
                hwuapi.DisplayValue(value);
            }
            else
            {
                // only display value on screen
                HelloWorld hw = new HelloWorld();
                hw.DisplayValue(value);
            }
        }
    }
}
