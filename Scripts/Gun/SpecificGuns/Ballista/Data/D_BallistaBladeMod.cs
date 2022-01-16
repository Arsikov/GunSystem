using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses.BallistaClasses
{
    [CreateAssetMenu(menuName = "Gun/Mod/Ballista/Blade")]
    public class D_BallistaBladeMod : D_GunMod
    {
        public float MaxChargeStepExtent;
        public int MaxChargeStepAmount;
        public int ChrageStepAmmoMultiplier;
    }
}
