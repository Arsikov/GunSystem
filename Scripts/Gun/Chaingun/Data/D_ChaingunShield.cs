using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    [CreateAssetMenu(menuName = "Gun/Chaingun/Shield")]
    public class D_ChaingunShield : ScriptableObject
    {
        public GameObject ShieldPrefab;
        public float DistFromShootPoint;
    }
}
