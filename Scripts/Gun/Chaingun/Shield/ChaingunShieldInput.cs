using System;
using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunShieldInput : GunShootInput
    {
        public event Action OnSpawnShield;
        public event Action OnRemoveShield;

        private D_ChaingunShieldInput D_shieldInput;

        private float _maxActiveTime;
        private bool _shieldActivated;

        public ChaingunShieldInput(Gun gun, D_ChaingunShieldInput D_shieldInput) : base(gun)
        {
            this.D_shieldInput = D_shieldInput;
            _maxActiveTime = D_shieldInput.MaxActiveTime;
            shootKey = D_shieldInput.ShootKey;

            _shieldActivated = false;
        }

        public override void HandleShootInput()
        {
            base.HandleShootInput();

            if (getShootKeyDown(shootKey) && !_shieldActivated)
            {
                _shieldActivated = true;
            }

            if(_shieldActivated)
            {
                _maxActiveTime -= Time.deltaTime;
                OnSpawnShield();

                if(_maxActiveTime < 0)
                {
                    OnRemoveShield();
                    _shieldActivated = false;
                    SetLastTimeShoot(minTimeBtwShoots);
                }
            }

            if (!_shieldActivated && _maxActiveTime < D_shieldInput.MaxActiveTime)
            {
                _maxActiveTime += Time.deltaTime;
            }
        }
    }
}