using System;
using System.Numerics;


using Base2Me.Utils.CSGO.Enums;

namespace Base2Me.Utils.CSGO.Structures
{
    public abstract class BaseEntity
    {
        private IntPtr _Address;
        private int _ClassID;

        public int ClassID
        {
            get
            {
                if (_ClassID == 0) { _ClassID = GetClassID(); }
                return _ClassID;
            }
            set
            {
               _ClassID = value;
            }
        }

        public int TeamNum
        {
            get { return 0; }
        }

        public Vector3 VecOrigin
        {
            get { return new Vector3(); }
        }

        public int OwnerEntity
        {
            get { return 0; }
        }

        public int Spotted
        {
            get { return 0; }
        }

        public int SpottedByMask
        {
            get { return 0; }
        }

        protected BaseEntity()
        {
            _Address = IntPtr.Zero;
        }

        protected BaseEntity(IntPtr Address)
        {
            _Address = Address;
        }


        protected int GetClassID()
        {
            return 0; //Temporary
        }

        public bool IsPlayer()
        {
            return _ClassID == (int)ClassIDs.CCSPlayer;
        }

        //Switch statement avoided, amen
        public bool IsWeapon()
        {
            return Enum.IsDefined(typeof(WeaponClassIDs), _ClassID);
        }

    }
}