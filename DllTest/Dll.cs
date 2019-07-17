using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DllTest
{
    public abstract class Dll
    {
        abstract public string GetValue();

        abstract public bool WriteValue(string value);
    }
}
