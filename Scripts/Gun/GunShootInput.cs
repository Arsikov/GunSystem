using UnityEngine;
using System;

namespace GunClasses
{
    public abstract class GunShootInput
    {
        public event Action OnShootInput;

        private Gun gun;

        public Vector2 DirToMouse { get; private set; }
        public float DistToMouse { get; private set; }
        public Vector2 MousePos { get; private set; }

        protected float lastTimeShoot;
        protected KeyCode shootKey;
        protected float minTimeBtwShoots;

        private Camera camera;

        public GunShootInput(Gun gun)
        {
            this.gun = gun;
            camera = Camera.main;
        }

        public virtual void HandleShootInput()
        {
            MousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            DistToMouse = Vector2.Distance(gun.ShootPoint.position, MousePos);
            DirToMouse = (MousePos - (Vector2)gun.ShootPoint.position).normalized;
        }

        protected bool isTimeBtwShootsPassed(float timeBtwShoots)
        {
            if (Time.time < lastTimeShoot + timeBtwShoots) return false;
            return true;
        }

        protected void SetLastTimeShoot(float timeBtwShoots)
        {
            lastTimeShoot = Time.time + timeBtwShoots;
        }


        protected bool getShootKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
        protected bool getShootKey(KeyCode key)
        {
            return Input.GetKey(key);
        }
        protected bool getShootKeyReleased(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }


        protected void RunOnShootInputEvent() => OnShootInput();
    }
}