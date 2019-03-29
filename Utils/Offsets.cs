using System;
using System.Collections.Generic;
using System.Text;

namespace Base2Me.Utils
{
    public class Offsets
    {
        //change to JSON...
        public int dwClientState;
        public int dwEntityList;
        public int dwGameRulesProxy;
        public int dwGlowObjectManager;
        public int dwLocalPlayer;
        
        public int m_fFlags;


        public Offsets()
        {
            dwClientState = 0x58BCFC;
            dwEntityList = 0x4CE350C;
            dwGameRulesProxy = 0x51F8CE4;
            dwGlowObjectManager = 0x5223730;
            dwLocalPlayer = 0xCD2764;

            m_fFlags = 0x104;
        }
    }
}
