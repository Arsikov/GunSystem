using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    [CreateAssetMenu(menuName = "Gun/Chaingun/Shoot")]
    public class D_ChaingunShoot : D_GunShoot
    {
        public GameObject ProjectilePrefab;
        public int ProjectileSpeed;
        public int ProjectileTravelDist;
        public float SpreadFactor;
    }
}