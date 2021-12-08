using System;
using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses
{
    public abstract class GunInput
    {
        public event Action OnModeDownInput;
        public event Action OnModeInput;
        public event Action OnModeUpInput;

        protected D_GunModeTriggerInput D_gunModeTriggerInput;

        private float _lastTimeTriggered;

        public GunInput(D_GunModeTriggerInput D_gunModeTriggerInput)
        {
            this.D_gunModeTriggerInput = D_gunModeTriggerInput;
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

        protected virtual void InvokeOnModeDownInputEvent()
        {
            OnModeDownInput();
        }
        protected virtual void InvokeOnModeInputEvent()
        {
            OnModeInput();
        }
        protected virtual void InvokeOnModeUpInputEvent()
        {
            OnModeUpInput();
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
