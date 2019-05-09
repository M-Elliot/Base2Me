using Base2Me.Utils.Managers;
using System;
using System.Runtime.InteropServices;

namespace Base2Me.Utils
{
    public static class SDK
    {
        #region Imports

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(ConsoleKey Key);

        #endregion Imports

        public static MemoryManager Memory;// = new MemoryManager("csgo");
        public static Settings Settings;// = new Settings();

        //public static ConsoleMenu ConsoleMenu;
        public static Offsets Offsets;// = new Offsets();

        //Temporary until we create the Entity Structs
        public static IntPtr LocalPlayer;
    }
}