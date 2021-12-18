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

        protected GunAmmoRequest _ammoRequest;

        private float _attackTime;

        public PlasmaRifleBaseMod(PlasmaRifleInput plasmaRifleInput, D_PlasmaRifleBaseMod D_plasmaRifleBaseMod, GunEnergyAmmoContainer energyAmmoContainer)
        {
            _plasmaRifleInput = plasmaRifleInput;

            this.D_plasmaRifleBaseMod = D_plasmaRifleBaseMod;

            _energyAmmoContainer = energyAmmoContainer;
            _attackTime = D_plasmaRifleBaseMod.AttackTime;

            plasmaRifleInput.OnBaseModFireInputDown += OnInputDown;
            plasmaRifleInput.OnBaseModFireInputPressed += OnInputPressed;

            OnPlasmaRifleBaseModFire += SetLastTimeFired;
            OnPlasmaRifleBaseModFire += RequestAmmo;
            OnPlasmaRifleBaseModFire += SpawnProjectile;
        }

        private void OnInputDown()
        {
            if (_ammoRequest.GetAmmoValue() > 0 && GetTimeSinceLastFirePassed(D_plasmaRifleBaseMod.MinTimeBtwFire))
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

        public void RequestAmmo()
        {
            _energyAmmoContainer.CallOnModifyAmmoEvent(-D_plasmaRifleBaseMod.AmmoCost);
        }
    }
}
