using System;
using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses.ShotgunClasses
{
    public class ShotgunShootInput : GunInput
    {
        public event Action OnBaseModeTriggerInput;

        public event Action OnFullAutoModeEnableInput;
        public event Action OnFullAutoModeTriggerInput;
        public event Action OnFullAutoModeDisablenput;

        private D_ShotgunBaseModInput D_baseModInput;
        private D_ShotgunFullAutoModInput D_fullAutoModInput;

        private float _attackTime;

        public ShotgunShootInput(D_GunModTriggerInput D_gunModTriggerInput, D_ShotgunBaseModInput D_baseModInput, D_ShotgunFullAutoModInput D_fullAutoModInput) : base(D_gunModTriggerInput)
        {
            this.D_baseModInput = D_baseModInput;
            this.D_fullAutoModInput = D_fullAutoModInput;

            _attackTime = D_fullAutoModInput.AttackTime;
        }

        protected override void HandleInput()
        {
            HandleBaseModeTriggerInput();
            HandleFullAutoModeTriggerInput();
        }

        private void HandleBaseModeTriggerInput()
        {
            if (GetKeyDown(D_gunModTriggerInput.BaseModTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModInput.MinTimeBtwTriggers))
            {
                OnBaseModeTriggerInput.Invoke();
                SetLastTimeTriggered();
            }
        }

        private void HandleFullAutoModeTriggerInput()
        {
            if (GetKey(D_gunModTriggerInput.SpecialModTriggerInput))
            {
                OnFullAutoModeEnableInput?.Invoke();

                if (GetKeyDown(D_gunModTriggerInput.BaseModTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModInput.MinTimeBtwTriggers))
                {
                    OnFullAutoModeTriggerInput?.Invoke();
                    SetLastTimeTriggered();
                }
            }

            if (GetKeyDown(D_gunModTriggerInput.BaseModTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModInput.MinTimeBtwTriggers))
            {
                _attackTime -= Time.deltaTime;

                if (_attackTime < 0)
                {
                    _attackTime = D_fullAutoModInput.AttackTime;

                    OnFullAutoModeTriggerInput?.Invoke();
                    SetLastTimeTriggered();
                }
            }
        }
    }   
}