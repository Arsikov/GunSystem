using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.BallistaClasses
{
    public class BallistaBaseMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnBallistaBaseModFire;

        private BallistaInput _ballistaInput;
        private D_BallistaBaseMod D_ballistaBaseMod;

        protected GunAmmoRequest _ammoRequest;

        public BallistaBaseMod(BallistaInput ballistaInput, D_BallistaBaseMod D_ballistaBaseMod, GunEnergyAmmoContainer energyAmmoContainer)
        {
            _ballistaInput = ballistaInput;

            this.D_ballistaBaseMod = D_ballistaBaseMod;

            _ammoRequest = new GunAmmoRequest(energyAmmoContainer, AmmoRequest);

            ballistaInput.OnBaseModFireInputDown += OnInputDown;

            OnBallistaBaseModFire += SetLastTimeFired;
            OnBallistaBaseModFire += RequestAmmo;
            OnBallistaBaseModFire += SpawnProjectile;
        }

        private void OnInputDown()
        {
            if (_ammoRequest.GetAmmoValue() > 0 && GetTimeSinceLastFirePassed(D_ballistaBaseMod.MinTimeBtwFire))
            {
                OnBallistaBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        public void RequestAmmo()
        { 
            _energyAmmoContainer.CallOnModifyAmmoEvent(-D_ballistaBaseMod.AmmoCost);
        }
    }
}
