using System;
using UnityEngine;

namespace GunClasses
{
    public abstract class GunMod
    {
        private float _lastTimeTrigger;

        public virtual void Update()
        {

        }
        
        public Vector3 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        protected bool GetTimeSinceLastFirePassed(float timeBtwTriggeres)
        {
            return Time.time <= _lastTimeTrigger + timeBtwTriggeres;
        }

        protected void SetLastTimeFired()
        {
            _lastTimeTrigger = Time.time;
        }
    }
}
