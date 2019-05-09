using Base2Me.Features;
using Base2Me.Utils;
using Base2Me.Utils.Managers;

using System;

namespace Base2Me
{
    public class Program
    {
        public BunnyHop BunnyHop;

        private static void Main(string[] args)
        {
            new Program().InitialiseThreads();
            //Hang until input, threads remain active.
            Console.ReadLine();
        }

        private void InitialiseThreads()
        {
            SDK.Settings = new Settings();
            var ConMenu = new ConsoleMenu();

            SDK.Offsets = new Offsets();
            SDK.Memory = new MemoryManager("csgo");
            BunnyHop = new BunnyHop();
        }
    }
}