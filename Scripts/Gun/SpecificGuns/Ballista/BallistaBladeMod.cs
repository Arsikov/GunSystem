using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.BallistaClasses
{
    public class BallistaBladeMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnBallistaBladeModFire;

        public event Action OnBallistaBladeModModEnabled;
        public event Action OnBallistaBladeModIsCharging;
        public event Action OnBallistaBladeModDisabled;

        private BallistaInput _ballistaInput;
        private D_BallistaBladeMod D_ballistaBladeMod;

        public GunAmmoRequest AmmoRequestSender { get; }

        private bool _modIsActivated;
        private bool _modFullyCharged;

        private float _currentStepChargeExtent;
        private int _currentStep;

        public BallistaBladeMod(BallistaInput ballistaInput, D_BallistaBladeMod D_ballistaBladeMod, GunEnergyAmmoContainer energyAmmoContainer)
        {
            _ballistaInput = ballistaInput;

            this.D_ballistaBladeMod = D_ballistaBladeMod;

            AmmoRequestSender = new GunAmmoRequest(energyAmmoContainer, AmmoRequest);

            _modIsActivated = false;
            _currentStepChargeExtent = 0;
            _currentStep = 0;

            #region Events
            ballistaInput.OnBladeModEnableInputDown += OnEnableInputDown;
            ballistaInput.OnBladeModChargeInputPressed += OnChargeInputPressed;
            ballistaInput.OnBladeModDisableInputUp += OnDisableInputUp;

            ballistaInput.OnBladeModFireInputDown += OnFireInputDown;

            OnBallistaBladeModModEnabled += OnBurstModEnabled;
            OnBallistaBladeModIsCharging += OnBurstModCharging;
            OnBallistaBladeModDisabled += OnBurstModDisabled;

            OnBallistaBladeModFire += SetLastTimeFired;
            OnBallistaBladeModFire += RequestAmmo;
            OnBallistaBladeModFire += SpawnProjectile;
            #endregion
        }

        #region OnInput
        private void OnEnableInputDown()
        {
            if (!_modIsActivated)
            {
                OnBallistaBladeModModEnabled?.Invoke();
            }
        }

        private void OnChargeInputPressed()
        {
            OnBallistaBladeModIsCharging?.Invoke();
        }

        private void OnDisableInputUp()
        {
            if (_modIsActivated)
            {
                OnBallistaBladeModDisabled?.Invoke();
            }
        }

        private void OnFireInputDown()
        {
            
        }

        #endregion

        #region MethodsCalleddOnEvent
        private void OnBurstModEnabled()
        {
            _modIsActivated = true;
        }

        private void OnBurstModCharging()
        {
            while(!_modFullyCharged) _currentStepChargeExtent += Time.deltaTime;

            if (_currentStepChargeExtent >= D_ballistaBladeMod.MaxChargeStepExtent)
            {
                _currentStep++;
                _currentStepChargeExtent = 0;

                if (_currentStep == D_ballistaBladeMod.MaxChargeStepAmount) _modFullyCharged = true;
            }
        }

        private void OnBurstModDisabled()
        {
            _modIsActivated = false;
            _currentStepChargeExtent = 0;
            _currentStep = 0;
        }
        private void SpawnProjectile()
        {
            // also spawn projectile of one of 2 types

            _modIsActivated = false;
            _currentStepChargeExtent = 0;
            _currentStep = 0;
        }
        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_ballistaBladeMod.AmmoCost * D_ballistaBladeMod.ChrageStepAmmoMultiplier);
        }
        #endregion
    }
}
