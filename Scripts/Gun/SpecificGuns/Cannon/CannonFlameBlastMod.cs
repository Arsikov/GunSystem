using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.CannonClasses
{
    public class CannonFlameBlastMod : GunMod
    {
        public event Action OnCannonFlameBlastModFire;

        public event Action OnCannonFlameBlastModEnabled;
        public event Action OnCannonFlameBlastModIsCharging;
        public event Action OnCannonFlameBlastModDisabled;

        private CannonInput _cannonInput;
        private D_CannonFlameBlastMod D_cannonFlameBlastMod;
        private GunBulletAmmoContainer _bulletAmmoContainer;

        private bool _modIsActivated;
        private float _chargeExtent;
        private bool _blastIsFullyCharged;

        public CannonFlameBlastMod(CannonInput cannonInput, D_CannonFlameBlastMod D_cannonFlameBlastMod, GunBulletAmmoContainer bulletAmmoContainer)
        {
            _cannonInput = cannonInput;

            this.D_cannonFlameBlastMod = D_cannonFlameBlastMod;

            _bulletAmmoContainer = bulletAmmoContainer;

            _modIsActivated = false;
            _chargeExtent = 0;

            cannonInput.OnFlameBlastModEnableInputDown += OnEnableInputDown;
            cannonInput.OnFlameBlastModChargeInputPressed += OnChargeInputPressed;
            cannonInput.OnFlameBlastModDisableInputUp += OnDisableInputUp;

            cannonInput.OnFlameBlastModFireInputDown += OnFireInputDown;

            OnCannonFlameBlastModFire += OnBurstModEnabled;
            OnCannonFlameBlastModIsCharging += OnBurstModCharging;
            OnCannonFlameBlastModDisabled += OnBurstModDisabled;

            OnCannonFlameBlastModFire += SetLastTimeFired;
            OnCannonFlameBlastModFire += ReduceAmmo;
            OnCannonFlameBlastModFire += SpawnProjectile;
        }

        #region OnInput
        private void OnEnableInputDown()
        {
            if (!_modIsActivated)
            {
                OnCannonFlameBlastModEnabled?.Invoke();
            }
        }
        private void OnChargeInputPressed()
        {
            OnCannonFlameBlastModIsCharging?.Invoke();
        }
        private void OnDisableInputUp()
        {
            if (_modIsActivated)
            {
                OnCannonFlameBlastModDisabled?.Invoke();
            }
        }
        private void OnFireInputDown()
        {
            if (_bulletAmmoContainer.AmmoAmount > D_cannonFlameBlastMod.AmmoCost && _blastIsFullyCharged)
            {
                OnCannonFlameBlastModFire?.Invoke();
            }
        }
        #endregion

        #region MethodsCalleddOnEvent
        private void OnBurstModEnabled()
        {
            _modIsActivated = true;
        }
        private void OnBurstModCharging()
        {
            _chargeExtent += Time.deltaTime;

            if (_chargeExtent >= D_cannonFlameBlastMod.ChargeTime)
            {
                _blastIsFullyCharged = true;
            }
        }
        private void OnBurstModDisabled()
        {
            _modIsActivated = false;
            _blastIsFullyCharged = false;
        }
        private void SpawnProjectile()
        {
            if (_blastIsFullyCharged)
            {

            }
        }
        private void ReduceAmmo()
        {
            _bulletAmmoContainer.CallOnReduceAmmoEvent(D_cannonFlameBlastMod.AmmoCost);
        }
        #endregion
    }
}
