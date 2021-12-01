using UnityEngine;

namespace GunClasses.ShotgunClasses
{
    [CreateAssetMenu(menuName = "Gun/Shotgun/Shoot")]
    public class D_ShotgunShoot : D_GunShoot
    {
        public GameObject ProjectilePrefab;
        public int ProjectileSpeed;
        public int ProjectileTravelDist;
        public float SpreadFactor;
        public int BulletsPerShoot;
    }
}