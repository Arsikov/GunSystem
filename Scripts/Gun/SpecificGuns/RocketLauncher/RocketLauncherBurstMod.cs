using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.RocketClasses
{
    public class RocketLauncherBurstMod : GunMod
    {
        public event Action OnRocketLauncherBurstModFire;

        public event Action OnRocketLauncherBurstModEnabled;
        public event Action OnRocketLauncherBurstModIsCharging;
        public event Action OnRocketLauncherBurstModDisabled;

        private RocketLauncherInput _rocketLauncherInput;
        private D_RocketLauncherBurstMod D_rocketLauncherBurstMod;
        private GunShellAmmoContainer _shellAmmoContainer;

        private bool _modIsActivated;
        private float _chargeExtent;
        private bool _burstIsFullyCharged;

        public RocketLauncherBurstMod(RocketLauncherInput rocketLauncherInput, D_RocketLauncherBurstMod D_rocketLauncherBurstMod, GunShellAmmoContainer shellAmmoContainer)
        {
            _rocketLauncherInput = rocketLauncherInput;

            this.D_rocketLauncherBurstMod = D_rocketLauncherBurstMod;

            _shellAmmoContainer = shellAmmoContainer;

            _modIsActivated = false;
            _chargeExtent = 0;

            rocketLauncherInput.OnBurstModEnableInputDown += OnEnableInputDown;
            rocketLauncherInput.OnBurstModChargeInputPressed += OnChargeInputPressed;
            rocketLauncherInput.OnBurstModDisableInputUp += OnDisableInputUp;

            rocketLauncherInput.OnBurstModFireInputDown += OnFireInputDown;

            OnRocketLauncherBurstModEnabled += OnBurstModEnabled;
            OnRocketLauncherBurstModIsCharging += OnBurstModCharging;
            OnRocketLauncherBurstModDisabled += OnBurstModDisabled;

            OnRocketLauncherBurstModFire += SetLastTimeFired;
            OnRocketLauncherBurstModFire += ReduceAmmo;
            OnRocketLauncherBurstModFire += SpawnProjectile;
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
            if (_shellAmmoContainer.AmmoAmount > D_rocketLauncherBurstMod.AmmoCost && _burstIsFullyCharged)
            {
                OnRocketLauncherBurstModFire?.Invoke();
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
        private void ReduceAmmo()
        {
            _shellAmmoContainer.CallOnReduceAmmoEvent(D_rocketLauncherBurstMod.AmmoCost);
        }
        #endregion
    }
}
