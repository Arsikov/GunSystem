using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.RocketClasses
{
    public class RocketLauncherBurstMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnRocketLauncherBurstModFire;

        public event Action OnRocketLauncherBurstModEnabled;
        public event Action OnRocketLauncherBurstModIsCharging;
        public event Action OnRocketLauncherBurstModDisabled;

        private RocketLauncherInput _rocketLauncherInput;
        private D_RocketLauncherBurstMod D_rocketLauncherBurstMod;

        protected GunAmmoRequest _ammoRequest;

        private bool _modIsActivated;
        private float _chargeExtent;
        private bool _burstIsFullyCharged;

        public GunAmmoRequest AmmoRequestSender { get; }

        public RocketLauncherBurstMod(RocketLauncherInput rocketLauncherInput, D_RocketLauncherBurstMod D_rocketLauncherBurstMod, GunShellAmmoContainer shellAmmoContainer)
        {
            _rocketLauncherInput = rocketLauncherInput;

            this.D_rocketLauncherBurstMod = D_rocketLauncherBurstMod;

            AmmoRequestSender = new GunAmmoRequest(shellAmmoContainer, AmmoRequest);

            _modIsActivated = false;
            _chargeExtent = 0;

            #region Events
            rocketLauncherInput.OnBurstModEnableInputDown += OnEnableInputDown;
            rocketLauncherInput.OnBurstModChargeInputPressed += OnChargeInputPressed;
            rocketLauncherInput.OnBurstModDisableInputUp += OnDisableInputUp;

            rocketLauncherInput.OnBurstModFireInputDown += OnFireInputDown;

            OnRocketLauncherBurstModEnabled += OnBurstModEnabled;
            OnRocketLauncherBurstModIsCharging += OnBurstModCharging;
            OnRocketLauncherBurstModDisabled += OnBurstModDisabled;

            OnRocketLauncherBurstModFire += SetLastTimeFired;
            OnRocketLauncherBurstModFire += RequestAmmo;
            OnRocketLauncherBurstModFire += SpawnProjectile;
            #endregion
        }

        #region OnInput
        private void OnEnableInputDown()
        {
            if (!_modIsActivated)
            {
                OnRocketLauncherBurstModEnabled?.Invoke();
            }
        }

        private void OnChargeInputPressed()
        {
            OnRocketLauncherBurstModIsCharging?.Invoke();
        }

        private void OnDisableInputUp()
        {
            if (_modIsActivated)
            {
                OnRocketLauncherBurstModDisabled?.Invoke();
            }
        }

        private void OnFireInputDown()
        {
            if (_ammoRequest.GetResourceValue() > D_rocketLauncherBurstMod.AmmoCost && _burstIsFullyCharged)
            {
                OnRocketLauncherBurstModFire?.Invoke();
            }
        }
        #endregion

        #region OnEvent
        private void OnBurstModEnabled()
        {
            _modIsActivated = true;
        }

        private void OnBurstModCharging()
        {
            _chargeExtent += Time.deltaTime;

            if(_chargeExtent >= D_rocketLauncherBurstMod.ChargeTime)
            {
                _burstIsFullyCharged = true;
            }
        }

        private void OnBurstModDisabled()
        {
            _modIsActivated = false;
            _burstIsFullyCharged = false;
        }

        private void SpawnProjectile()
        {
            if (_burstIsFullyCharged)
            {

            }
        }

        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_rocketLauncherBurstMod.AmmoCost);
        }
        #endregion
    }
}
