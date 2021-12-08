using System;
using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunInput : GunInput   
    {
        public event Action OnSpawnShielModeInput;
        public event Action OnRemoveShieldModeInput;

        private D_ChaingunBaseModeInput D_baseModeInput;
        private D_ChaingunShieldModeInput D_shieldModeInput;

        private float _attackTime;

        private float _maxActiveTime;
        private bool _shieldActivated;

        private Chaingun _chaingun;

        public ChaingunInput(D_GunModeTriggerInput D_gunModeTriggerInput, Chaingun chaingun, D_ChaingunBaseModeInput D_baseModeInput, D_ChaingunShieldModeInput D_shieldModeInput) : base(D_gunModeTriggerInput)
        {
            this.D_baseModeInput = D_baseModeInput;
            this.D_shieldModeInput = D_shieldModeInput;

            _attackTime = D_baseModeInput.AttackTime;

            _maxActiveTime = D_shieldModeInput.MaxActiveTime;
            _shieldActivated = false;
        }

        protected override void HandleInput()
        {
            HandleBaseModeTriggerInput();
            HandleShieldModeTriggerInput();
        }

        private void HandleBaseModeTriggerInput()
        {
            if (GetKeyDown(D_gunModeTriggerInput.BaseModeTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModeInput.MinTimeBtwTriggers))
            {
                InvokeOnModeDownInputEvent();
                SetLastTimeTriggered();
            }

            if (GetKeyDown(D_gunModeTriggerInput.BaseModeTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModeInput.MinTimeBtwTriggers))
            {
                _attackTime -= Time.deltaTime;

                if (_attackTime < 0)
                {
                    _attackTime = D_baseModeInput.AttackTime;

                    InvokeOnModeDownInputEvent();
                    SetLastTimeTriggered();
                }
            }
        }

        private void HandleShieldModeTriggerInput()
        {
            if (GetKeyDown(D_gunModeTriggerInput.BaseModeTriggerInput) && !_shieldActivated)
            {
                _shieldActivated = true;
            }

            if (_shieldActivated)
            {
                _maxActiveTime -= Time.deltaTime;
                OnSpawnShielModeInput();

                if (_maxActiveTime < 0)
                {
                    OnRemoveShieldModeInput();
                    _shieldActivated = false;
                    SetLastTimeTriggered();
                }
            }

            while(!_shieldActivated && _maxActiveTime < D_shieldModeInput.MaxActiveTime)
            {
                _maxActiveTime += Time.deltaTime;
            }
        }

        protected override void InvokeOnModeDownInputEvent()
        {
            base.InvokeOnModeDownInputEvent();


        }
    }
}