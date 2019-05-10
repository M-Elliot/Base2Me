using Base2Me.Utils.Managers;
using System;
using System.Runtime.InteropServices;

namespace Base2Me.Utils
{
    public static class SDK
    {
        #region DLLImports

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(ConsoleKey Key);

        #endregion DLLImports

        //Temporary until we create the Entity Structs
        public static IntPtr LocalPlayer;

        public static MemoryManager Memory;
        public static Offsets Offsets = new Offsets();
        public static Settings Settings = new Settings();
    }
}