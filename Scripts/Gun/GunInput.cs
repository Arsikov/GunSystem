using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses
{
    public abstract class GunInput
    {
        protected D_GunModTriggerInput D_gunModTriggerInput;

        private float _lastTimeTriggered;

        public GunInput(D_GunModTriggerInput D_gunModTriggerInput)
        {
            this.D_gunModTriggerInput = D_gunModTriggerInput;
        }

        public void Execute()
        {
            HandleInput();
        }

        protected abstract void HandleInput();

        public Vector3 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        protected bool GetKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
        protected bool GetKey(KeyCode key)
        {
            return Input.GetKey(key);
        }

        protected void SetLastTimeTriggered()
        {
            _lastTimeTriggered = Time.time;
        }

        protected bool GetTimeSinceLastTriggerPassed(float timeBtwTriggeres)
        {
            return Time.time <= _lastTimeTriggered + timeBtwTriggeres;
        }
    }
}
