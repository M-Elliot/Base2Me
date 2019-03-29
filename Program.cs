using System;
using Base2Me.Utils;
using Base2Me.Features;
namespace Base2Me
{
    public class Program
    {
        public BunnyHop BunnyHop;

         static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().InitialiseThreads();
            Console.ReadLine();
        }
        void InitialiseThreads()
        {
            BunnyHop = new BunnyHop();
        }

    }
}
