using UnityEngine;

namespace GunClasses.DataClasses
{
    public abstract class D_GunMode : ScriptableObject
    {
        public int Damage;
        public int ForceToHitObject;
        public float TimeBtwShoots;
    }
}
