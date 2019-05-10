using Base2Me.Features;
using Base2Me.Utils;
using Base2Me.Utils.Managers;

using System;

namespace Base2Me
{
    public class Program
    {
        public BunnyHop BunnyHop;
        public ConsoleMenu ConsoleMenu;

        //Our Main Method
        private static void Main(string[] args)
        {
            new Program().InitialiseClient();
            //Hang until input, threads remain active.
            Console.ReadLine();
        }

        private void InitialiseClient()
        {
            //Initialise console, loops here until settings escaped
            ConsoleMenu = new ConsoleMenu();
            SDK.Memory = new MemoryManager("csgo");
            BunnyHop = new BunnyHop();
        }
    }
}