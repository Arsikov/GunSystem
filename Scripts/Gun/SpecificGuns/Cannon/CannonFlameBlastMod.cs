using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.CannonClasses
{
    public class CannonFlameBlastMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnCannonFlameBlastModFire;

        public event Action OnCannonFlameBlastModEnabled;
        public event Action OnCannonFlameBlastModIsCharging;
        public event Action OnCannonFlameBlastModDisabled;

        private CannonInput _cannonInput;
        private D_CannonFlameBlastMod D_cannonFlameBlastMod;

        public GunAmmoRequest AmmoRequestSender { get; }

        private bool _modIsActivated;
        private float _chargeExtent;
        private bool _blastIsFullyCharged;

        public CannonFlameBlastMod(CannonInput cannonInput, D_CannonFlameBlastMod D_cannonFlameBlastMod, GunBulletAmmoContainer bulletAmmoContainer)
        {
            _cannonInput = cannonInput;

            this.D_cannonFlameBlastMod = D_cannonFlameBlastMod;

            AmmoRequestSender = new GunAmmoRequest(bulletAmmoContainer, AmmoRequest);

            _modIsActivated = false;
            _chargeExtent = 0;

            #region Events
            cannonInput.OnFlameBlastModEnableInputDown += OnEnableInputDown;
            cannonInput.OnFlameBlastModChargeInputPressed += OnChargeInputPressed;
            cannonInput.OnFlameBlastModDisableInputUp += OnDisableInputUp;

            cannonInput.OnFlameBlastModFireInputDown += OnFireInputDown;

            OnCannonFlameBlastModFire += OnBurstModEnabled;
            OnCannonFlameBlastModIsCharging += OnBurstModCharging;
            OnCannonFlameBlastModDisabled += OnBurstModDisabled;

            OnCannonFlameBlastModFire += SetLastTimeFired;
            OnCannonFlameBlastModFire += RequestAmmo;
            OnCannonFlameBlastModFire += SpawnProjectile;
            #endregion
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
            if (AmmoRequestSender.GetResourceValue() > D_cannonFlameBlastMod.AmmoCost && _blastIsFullyCharged)
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
        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_cannonFlameBlastMod.AmmoCost);
        }
        #endregion
    }
}
