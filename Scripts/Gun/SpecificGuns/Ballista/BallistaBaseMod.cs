using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.BallistaClasses
{
    public class BallistaBaseMod : GunMod
    {
        public event Action OnBallistaBaseModFire;

        private BallistaInput _ballistaInput;
        private D_BallistaBaseMod D_ballistaBaseMod;
        private GunEnergyAmmoContainer _energyAmmoContainer;

        public BallistaBaseMod(BallistaInput ballistaInput, D_BallistaBaseMod D_ballistaBaseMod, GunEnergyAmmoContainer energyAmmoContainer)
        {
            _ballistaInput = ballistaInput;

            this.D_ballistaBaseMod = D_ballistaBaseMod;

            _energyAmmoContainer = energyAmmoContainer;

            ballistaInput.OnBaseModFireInputDown += OnInputDown;

            OnBallistaBaseModFire += SetLastTimeFired;
            OnBallistaBaseModFire += ReduceAmmo;
            OnBallistaBaseModFire += SpawnProjectile;
        }

        private void OnInputDown()
        {
            if (_energyAmmoContainer.AmmoAmount > 0 && GetTimeSinceLastFirePassed(D_ballistaBaseMod.MinTimeBtwFire))
            {
                OnBallistaBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        private void ReduceAmmo()
        { 
            _energyAmmoContainer.CallOnReduceAmmoEvent(D_ballistaBaseMod.AmmoCost);
        }
    }
}
