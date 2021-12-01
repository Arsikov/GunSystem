using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunShoot : GunShoot
    {
        private Chaingun _chaingun;
        private D_ChaingunShoot D_СhaingunShoot;

        public ChaingunShoot(Chaingun chaingun, D_ChaingunShoot D_ChaingunShoot)
        {
            _chaingun = chaingun;
            this.D_СhaingunShoot = D_ChaingunShoot;
        }

        protected override void Shoot()
        {
            base.Shoot();

            Vector2 dirToMouse = SetSpreadFactor(_chaingun.ShootInput.DirToMouse, D_СhaingunShoot.SpreadFactor);

            Projectile projectile = GameObject.Instantiate(D_СhaingunShoot.ProjectilePrefab.GetComponent<Projectile>(), _chaingun.ShootPoint.position, Quaternion.identity);
            projectile.SetData(D_СhaingunShoot.Damage, D_СhaingunShoot.ProjectileSpeed, D_СhaingunShoot.ProjectileTravelDist, D_СhaingunShoot.HitObjectForce, dirToMouse);

            float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x);
            projectile.SetRigidBodyRotation(angle);
        }
    }
}