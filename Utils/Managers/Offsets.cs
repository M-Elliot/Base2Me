namespace Base2Me.Utils.Managers
{
    public class Offsets
    {
        //change to JSON...
        public int dwClientState;

        public int dwEntityList;
        public int dwForceJump;
        public int dwGameRulesProxy;
        public int dwGlowObjectManager;
        public int dwLocalPlayer;

        public int m_fFlags;

        public Offsets()
        {
            dwClientState = 0x58BCFC;
            dwEntityList = 0x4CFD57C;
            dwGameRulesProxy = 0x5212E2C;
            dwGlowObjectManager = 0x523D918;
            dwLocalPlayer = 0xCEB9BC;
            m_fFlags = 0x104;

            dwForceJump = 0x51A0AE4;
            // 04/05/19 offset date
        }
    }
}