using System;
using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunInput : GunInput   
    {
        public event Action OnBaseModInput;

        public event Action OnSpawnShielModInput;
        public event Action OnRemoveShieldModeInput;

        private D_ChaingunBaseModInput D_baseModInput;
        private D_ChaingunShieldModInput D_shieldModInput;

        private float _attackTime;

        private float _maxActiveTime;
        private bool _shieldActivated;

        public ChaingunInput(D_GunModTriggerInput D_gunModTriggerInput, D_ChaingunBaseModInput D_baseModInput, D_ChaingunShieldModInput D_shieldModInput) : base(D_gunModTriggerInput)
        {
            this.D_baseModInput = D_baseModInput;
            this.D_shieldModInput = D_shieldModInput;

            _attackTime = D_baseModInput.AttackTime;

            _maxActiveTime = D_shieldModInput.MaxActiveTime;
            _shieldActivated = false;
        }

        protected override void HandleInput()
        {
            HandleBaseModeTriggerInput();
            HandleShieldModeTriggerInput();
        }

        private void HandleBaseModeTriggerInput()
        {
            if (GetKeyDown(D_gunModTriggerInput.BaseModTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModInput.MinTimeBtwTriggers))
            {
                OnBaseModInput?.Invoke();
                SetLastTimeTriggered();
            }

            if (GetKeyDown(D_gunModTriggerInput.BaseModTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModInput.MinTimeBtwTriggers))
            {
                _attackTime -= Time.deltaTime;

                if (_attackTime < 0)
                {
                    _attackTime = D_baseModInput.AttackTime;

                    OnBaseModInput?.Invoke();
                    SetLastTimeTriggered();
                }
            }
        }

        private void HandleShieldModeTriggerInput()
        {
            if (GetKeyDown(D_gunModTriggerInput.BaseModTriggerInput) && !_shieldActivated)
            {
                _shieldActivated = true;
            }

            if (_shieldActivated)
            {
                _maxActiveTime -= Time.deltaTime;
                OnSpawnShielModInput?.Invoke();

                if (_maxActiveTime < 0)
                {
                    OnRemoveShieldModeInput?.Invoke();
                    _shieldActivated = false;
                    SetLastTimeTriggered();
                }
            }

            while(!_shieldActivated && _maxActiveTime < D_shieldModInput.MaxActiveTime)
            {
                _maxActiveTime += Time.deltaTime;
            }
        }
    }
}