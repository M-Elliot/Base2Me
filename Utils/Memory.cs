using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Numerics;
using System.Threading;

namespace Base2Me.Utils
{
    class MemoryClass
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern object ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out, MarshalAs(UnmanagedType.AsAny)] object lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);

        public Process GameProcess;

        public MemoryClass(string ProcessName)
        {
            while(true)
            {
                if (Process.GetProcessesByName(ProcessName).Length > 0)
                {
                    Console.WriteLine(ProcessName + " Detected...");
                    Thread.Sleep(5000);
                    GameProcess = Process.GetProcessesByName(ProcessName)[0];
                    break;
                }
                Thread.Sleep(100);
            }
        }

        private void ReadProcess(IntPtr Address, object ObjValue)
        {
            IntPtr Crap = new IntPtr();
            ReadProcessMemory(GameProcess.Handle, Address, ObjValue, Marshal.SizeOf(ObjValue), Crap);
        }

        public int ReadInteger(IntPtr Address, int Value)
        {
            ReadProcess(Address, Value);
            return Value;
        }

        public T ReadObject<T>(IntPtr Address, T ObjValue)
        {
            ReadProcess(Address, ObjValue);
            return ObjValue;
        }

        public Vector3 ReadVector3(IntPtr Address, Vector3 Vector)
        {
            ReadProcess(Address, Vector);
            return Vector;
        }



    }
}
