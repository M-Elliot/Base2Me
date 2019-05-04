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

        public int dwForceJump;

        public Offsets()
        {
            dwClientState = 0x58BCFC;
            dwEntityList = 0x4CFD35C;
            dwGameRulesProxy = 0x5212C0C;
            dwGlowObjectManager = 0x523D718;
            dwLocalPlayer = 0xCEB95C;
            m_fFlags = 0x104;

            dwForceJump = 0x51A08C4;
            // 04/05/19 offset date
        }
    }
}