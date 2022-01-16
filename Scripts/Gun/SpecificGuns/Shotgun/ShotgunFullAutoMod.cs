using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.ShotgunClasses
{
    public class ShotgunFullAutoMode : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnShotgunFullAutoModFire;

        public event Action OnShotgunFullAutoModEnabled;
        public event Action OnShotgunFullAutoModIsActivated;
        public event Action OnShotgunFullAutoModDisabled;

        private ShotgunInput _shotgunInput;
        private D_ShotgunFullAutoMod D_shotgunFullAutoMod;

        public GunAmmoRequest AmmoRequestSender { get; }

        private bool _modIsActivated;
        private float _attackTime;

        public ShotgunFullAutoMode(ShotgunInput shotgunInput, D_ShotgunFullAutoMod D_shotgunFullAutoMod, GunShellAmmoContainer shellAmmoContainer)
        {
            _shotgunInput = shotgunInput;
            AmmoRequestSender = new GunAmmoRequest(shellAmmoContainer, AmmoRequest);

            this.D_shotgunFullAutoMod = D_shotgunFullAutoMod;

            _modIsActivated = false;
            _attackTime = D_shotgunFullAutoMod.AttackTime;

            #region Events
            shotgunInput.OnFullAutoModEnableInputDown += OnEnableInputDown;
            shotgunInput.OnFullAutoModEnableInputPressed += OnEnableInputPressed;
            shotgunInput.OnFullAutoModDisableInputUp += OnDisableInputUp;

            shotgunInput.OnFullAutoModFireInputDown += OnFireInputDown;
            shotgunInput.OnFullAutoModFireInputPressed += OnFireInputPressed;

            OnShotgunFullAutoModEnabled += OnFullAutoModEnabled;
            OnShotgunFullAutoModDisabled += OnFullAutoModDisabled;

            OnShotgunFullAutoModFire += SetLastTimeFired;
            OnShotgunFullAutoModFire += RequestAmmo;
            OnShotgunFullAutoModFire += SpawnProjectile;
            #endregion
        }

        #region OnInput
        private void OnEnableInputDown()
        {
            OnShotgunFullAutoModEnabled?.Invoke();
        }

        private void OnEnableInputPressed()
        {
            OnShotgunFullAutoModIsActivated?.Invoke();
        }

        private void OnDisableInputUp()
        {
            OnShotgunFullAutoModDisabled?.Invoke();
        }

        private void OnFireInputDown()
        {
            if (AmmoRequestSender.GetResourceValue() > D_shotgunFullAutoMod.AmmoCost && GetTimeSinceLastFirePassed(D_shotgunFullAutoMod.MinTimeBtwFire))
            {
                OnShotgunFullAutoModFire?.Invoke();
            }
        }

        private void OnFireInputPressed()
        {
            _attackTime -= Time.deltaTime;

            if (_attackTime <= 0)
            {
                _attackTime = D_shotgunFullAutoMod.AttackTime;
                OnShotgunFullAutoModFire?.Invoke();
            }
        }
        #endregion

        #region OnEvent
        private void OnFullAutoModEnabled()
        {
            _modIsActivated = true;
            OnShotgunFullAutoModEnabled?.Invoke();
        }

        private void OnFullAutoModActivated()
        {
            OnShotgunFullAutoModIsActivated?.Invoke();
        }

        private void OnFullAutoModDisabled()
        {
            _modIsActivated = false;
            OnShotgunFullAutoModDisabled?.Invoke();
        }

        private void SpawnProjectile()
        {

        }

        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_shotgunFullAutoMod.AmmoCost);
        }
        #endregion
    }
}