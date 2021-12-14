using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.PlasmaClasses
{
    public class PlasmaRifleBaseMod : GunMod
    {
        public event Action OnPlasmaRifleBaseModFire;

        private PlasmaRifleInput _plasmaRifleInput;
        private D_PlasmaRifleBaseMod D_plasmaRifleBaseMod;
        private GunEnergyAmmoContainer _energyAmmoContainer;

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
            OnPlasmaRifleBaseModFire += ReduceAmmo;
            OnPlasmaRifleBaseModFire += SpawnProjectile;
        }

        private void OnInputDown()
        {
            if (_energyAmmoContainer.AmmoAmount > 0 && GetTimeSinceLastFirePassed(D_plasmaRifleBaseMod.MinTimeBtwFire))
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

        private void ReduceAmmo()
        {
            _energyAmmoContainer.CallOnReduceAmmoEvent(D_plasmaRifleBaseMod.AmmoCost);
        }
    }
}
