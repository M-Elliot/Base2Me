using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Base2Me.Utils.Managers
{
    public class MemoryManager
    {
        #region DLLImports

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] buffer, Int32 size, [Out] IntPtr lpNumberOfBytesWritten);

        #endregion DLLImports

        //Move these to Offsets maybe????
        public ProcessModule ClientPanoramaModule;

        public ProcessModule EngineModule;
        public Process GameProcess;

        public MemoryManager(string ProcessName)
        {
            Console.WriteLine("Waiting for csgo...");

            while (true)
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

            Console.WriteLine("Identifying Module Bases...");

            foreach (ProcessModule Module in GameProcess.Modules)
            {
                switch (Module.ModuleName)
                {
                    case "client_panorama.dll":
                        Console.WriteLine("client_panorama.dll located");
                        ClientPanoramaModule = Module;
                        break;

                    case "engine.dll":
                        Console.WriteLine("engine.dll located");
                        EngineModule = Module;
                        break;
                }
            }
        }

        #region Read

        /// <summary>
        /// Settled with a fixed size buffer over GC from a performance perspective.
        /// As a result have to allow unsafe code to use the fixed buffer.
        /// </summary>
        public unsafe T ReadProcess<T>(IntPtr Address)
        {
            byte[] ObjBuffer = new byte[Marshal.SizeOf<T>()];
            ReadProcessMemory(GameProcess.Handle, Address, ObjBuffer, Marshal.SizeOf<T>(), IntPtr.Zero);

            fixed (byte* byteBuffer = ObjBuffer)
            {
                return (T)Marshal.PtrToStructure(new IntPtr(byteBuffer), typeof(T));
            }
        }

        #endregion Read

        #region Write

        public void WriteNormal(IntPtr Address, Byte[] ObjValue)
        {
            WriteProcessMemory(GameProcess.Handle, Address, ObjValue, ObjValue.Length, IntPtr.Zero);
        }

        // I might change this
        public void WriteProcess<T>(IntPtr Address, T ObjValue)
        {
            IntPtr BufferPtr = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
            byte[] ByteObject = new byte[Marshal.SizeOf<T>()];
            Marshal.StructureToPtr(ObjValue, BufferPtr, false);
            Marshal.Copy(BufferPtr, ByteObject, 0, Marshal.SizeOf<T>());
            Marshal.FreeHGlobal(BufferPtr);
            WriteProcessMemory(GameProcess.Handle, Address, ByteObject, ByteObject.Length, IntPtr.Zero);
        }

        #endregion Write
    }
}