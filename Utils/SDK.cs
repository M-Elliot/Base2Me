using System;
using System.Collections.Generic;
using System.Text;
namespace Base2Me.Utils
{
    public static class SDK
    {
        public static MemoryManager Memory = new MemoryManager("csgo");
        public static Offsets Offsets = new Offsets();
        //Temporary until we create the Entity Structs
        public static int LocalPlayer;
    }
}
