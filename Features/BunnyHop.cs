using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Base2Me.Utils;
using Base2Me.Utils.Enums;
namespace Base2Me.Features
{
    public class BunnyHop
    {
        public BunnyHop()
        {
            new Thread(new ThreadStart(Main));
        }
        public void Main()
        {
            //temporary until create Entity Structs;
            do
            {
                if (SDK.Memory.ReadInteger(IntPtr.Add(SDK.Memory.ClientPanoramaModule.BaseAddress, SDK.Offsets.dwLocalPlayer), SDK.LocalPlayer) != 0)
                {
                    int m_flag = SDK.LocalPlayer & SDK.Offsets.m_fFlags;
                    if (m_flag == (int)GeneralBitFlags.FL_ONGROUND)
                    {

                    }
                }

                Thread.Sleep(10);
            } while (!SDK.Memory.GameProcess.HasExited);
        }
    }
}
