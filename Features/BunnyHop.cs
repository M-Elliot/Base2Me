﻿using Base2Me.Utils;
using Base2Me.Utils.Enums;
using System;
using System.Threading;

namespace Base2Me.Features
{
    public class BunnyHop
    {
        public BunnyHop()
        {
            Thread bThread = new Thread(new ThreadStart(Main));
            bThread.Start();
        }

        public void Main()
        {
            //temporary until create Entity Structs;
            do
            {
                SDK.LocalPlayer = SDK.Memory.ReadProcess<IntPtr>(IntPtr.Add(SDK.Memory.ClientPanoramaModule.BaseAddress, SDK.Offsets.dwLocalPlayer));
                if (SDK.LocalPlayer != IntPtr.Zero)
                {
                    int m_flag = SDK.Memory.ReadProcess<int>(IntPtr.Add(SDK.LocalPlayer, SDK.Offsets.m_fFlags));
                    if (SDK.GetAsyncKeyState(ConsoleKey.Spacebar) < 0)
                    {
                        if ((m_flag & (int)GeneralBitFlags.FL_ONGROUND) != 0)
                        {
                        //Console.WriteLine("GROUND");
                        SDK.Memory.WriteNormal(IntPtr.Add(SDK.Memory.ClientPanoramaModule.BaseAddress, SDK.Offsets.dwForceJump), BitConverter.GetBytes(5));              
                        }
                        else
                        {
                        //Console.WriteLine("AIR");
                        SDK.Memory.WriteNormal(IntPtr.Add(SDK.Memory.ClientPanoramaModule.BaseAddress, SDK.Offsets.dwForceJump), BitConverter.GetBytes(4));
                        }
                    }
                }
                Thread.Sleep(1);
            } while (!SDK.Memory.GameProcess.HasExited);
        }
    }
}