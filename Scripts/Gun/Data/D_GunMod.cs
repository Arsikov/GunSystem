using UnityEngine;

namespace GunClasses.DataClasses
{
    public abstract class D_GunMod : ScriptableObject
    {
        public int AmmoCost;
        public float MinTimeBtwFire;
        public int Damage;
        public int ForceToHitObject;
    }
}
