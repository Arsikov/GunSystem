using UnityEngine;

namespace GunClasses.ShotgunClasses
{
    public class ShotgunShoot : GunShoot
    {
        private Shotgun shotgun;
        private D_ShotgunShoot D_shotgunShoot;

        private int bulletsPerShoot;

        public ShotgunShoot(Shotgun shotgun, D_ShotgunShoot D_shogunShoot)
        {
            this.shotgun = shotgun;
            this.D_shotgunShoot = D_shogunShoot;

            bulletsPerShoot = D_shogunShoot.BulletsPerShoot;
        }

        protected override void Shoot()
        {
            base.Shoot();

            Vector2 dirToMouse = SetSpreadFactor(shotgun.ShootInput.DirToMouse, D_shotgunShoot.SpreadFactor);

            if (bulletsPerShoot > 0)
            {
                for (; bulletsPerShoot > 0; bulletsPerShoot--)
                {
                    Projectile projectile = GameObject.Instantiate(D_shotgunShoot.ProjectilePrefab.GetComponent<Projectile>(), shotgun.ShootPoint.position, Quaternion.identity);
                    projectile.SetData(D_shotgunShoot.Damage, D_shotgunShoot.ProjectileSpeed, D_shotgunShoot.ProjectileTravelDist, D_shotgunShoot.HitObjectForce, dirToMouse);
                    float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x);
                    projectile.SetRigidBodyRotation(angle);
                }

                bulletsPerShoot = D_shotgunShoot.BulletsPerShoot;
            }
        }
    }
}