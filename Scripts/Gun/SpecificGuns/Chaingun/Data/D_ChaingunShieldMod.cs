using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses.ChaingunClasses
{
    [CreateAssetMenu(menuName = "Gun/Mod/Chaingun/Shield")]
    public class D_ChaingunShieldMod : D_GunMod
    {
        public GameObject ShieldPrefab;
        public float MaxActivateTime;
        public float TimeUnitToSpendAmmo;
    }
}
