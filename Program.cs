using System;
using Base2Me.Utils;

namespace Base2Me
{
    class Program
    {
        Utils.SDKClass SDK = null;
         static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Utils.SDKClass SDK = new Utils.SDKClass("csgo");
            Console.ReadLine();
        }

    }
}
