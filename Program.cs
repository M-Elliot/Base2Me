using Base2Me.Features;
using System;

namespace Base2Me
{
    public class Program
    {
        public BunnyHop BunnyHop;

        private static void Main(string[] args)
        {
            Console.WriteLine("Open Source - Base2Me!");
            new Program().InitialiseThreads();

            //Hang until input, threads remain active.
            Console.ReadLine();
        }

        private void InitialiseThreads()
        {
            BunnyHop = new BunnyHop();
        }
    }
}