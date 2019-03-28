using System;
using System.Collections.Generic;
using System.Text;

namespace Base2Me.Utils
{
    public class SDKClass
    {
        MemoryClass Memory;
        OffsetsClass Offsets;

        public SDKClass(string ProcessName)
        {
            Memory = new MemoryClass(ProcessName);
            Offsets = new OffsetsClass();
        }
    }
}
