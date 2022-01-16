using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses.PlasmaClasses
{
    [CreateAssetMenu(menuName = "Gun/Mod/PlasmaRifle/StunBlast")]
    public class D_PlasmaRifleStunBlastMod : D_GunMod
    {
        public int BlastMaxAmount;
        public int BlastWeight;
        public int BaseShotToBlastWeightRelation;
    }
}
