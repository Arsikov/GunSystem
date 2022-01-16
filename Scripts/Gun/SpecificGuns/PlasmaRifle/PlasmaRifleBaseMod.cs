using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.PlasmaClasses
{
    public class PlasmaRifleBaseMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnPlasmaRifleBaseModFire;

        private PlasmaRifleInput _plasmaRifleInput;
        private D_PlasmaRifleBaseMod D_plasmaRifleBaseMod;

        public ResourceRequest AmmoRequestSender { get; private set; }

        private float _attackTime;

        public PlasmaRifleBaseMod(PlasmaRifleInput plasmaRifleInput, D_PlasmaRifleBaseMod D_plasmaRifleBaseMod, GunEnergyAmmoContainer energyAmmoContainer)
        {
            _plasmaRifleInput = plasmaRifleInput;

            this.D_plasmaRifleBaseMod = D_plasmaRifleBaseMod;

            AmmoRequestSender = new ResourceRequest(energyAmmoContainer, AmmoRequest);
            _attackTime = D_plasmaRifleBaseMod.AttackTime;

            #region Events
            plasmaRifleInput.OnBaseModFireInputDown += OnInputDown;
            plasmaRifleInput.OnBaseModFireInputPressed += OnInputPressed;

            OnPlasmaRifleBaseModFire += SetLastTimeFired;
            OnPlasmaRifleBaseModFire += RequestAmmo;
            OnPlasmaRifleBaseModFire += SpawnProjectile;
            #endregion
        }

        private void OnInputDown()
        {
            if (AmmoRequestSender.GetResourceValue() > 0 && GetTimeSinceLastFirePassed(D_plasmaRifleBaseMod.MinTimeBtwFire))
            {
                OnPlasmaRifleBaseModFire?.Invoke();
            }
        }

        private void OnInputPressed()
        {
            _attackTime -= Time.deltaTime;

            if (_attackTime <= 0)
            {
                _attackTime = D_plasmaRifleBaseMod.AttackTime;
                OnPlasmaRifleBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_plasmaRifleBaseMod.AmmoCost);
        }
    }
}
