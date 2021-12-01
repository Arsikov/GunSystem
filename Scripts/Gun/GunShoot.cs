using UnityEngine;
using System;

namespace GunClasses
{
    public abstract class GunShoot
    {
        public event Action OnShoot;

        public GunShoot()
        {
            OnShoot += Shoot;
        }

        protected virtual void Shoot()
        {

        }

        public void RunShootEvent()
        {
            OnShoot();
        }

        protected Vector2 SetSpreadFactor(Vector2 dir, float spread)
        {
            dir = new Vector2(dir.x + UnityEngine.Random.Range(-spread, 0), dir.y + UnityEngine.Random.Range(-spread, 0));
            return dir;
        }
    }
}