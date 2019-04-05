using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Base2Me.Utils
{
    public static class SDK
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(System.Int32 vKey);

        public static MemoryManager Memory = new MemoryManager("csgo");
        public static Offsets Offsets = new Offsets();
        //Temporary until we create the Entity Structs
        public static IntPtr LocalPlayer;
    }
}
