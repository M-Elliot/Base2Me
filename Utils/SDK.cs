using System;
using System.Runtime.InteropServices;

namespace Base2Me.Utils
{
    public static class SDK
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(ConsoleKey vKey);

        public static MemoryManager Memory = new MemoryManager("csgo");
        public static Offsets Offsets = new Offsets();

        //Temporary until we create the Entity Structs
        public static IntPtr LocalPlayer;
    }
}