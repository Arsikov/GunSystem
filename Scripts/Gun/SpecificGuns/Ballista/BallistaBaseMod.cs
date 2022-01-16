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

        public GunAmmoRequest AmmoRequestSender { get; }

        public BallistaBaseMod(BallistaInput ballistaInput, D_BallistaBaseMod D_ballistaBaseMod, GunEnergyAmmoContainer energyAmmoContainer)
        {
            _ballistaInput = ballistaInput;

            this.D_ballistaBaseMod = D_ballistaBaseMod;

            AmmoRequestSender = new GunAmmoRequest(energyAmmoContainer, AmmoRequest);

            #region Events
            ballistaInput.OnBaseModFireInputDown += OnInputDown;

            OnBallistaBaseModFire += SetLastTimeFired;
            OnBallistaBaseModFire += RequestAmmo;
            OnBallistaBaseModFire += SpawnProjectile;
            #endregion
        }

        private void OnInputDown()
        {
            if (AmmoRequestSender.GetResourceValue() > 0 && GetTimeSinceLastFirePassed(D_ballistaBaseMod.MinTimeBtwFire))
            {
                OnBallistaBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        protected void RequestAmmo()
        { 
            AmmoRequest?.Invoke(-D_ballistaBaseMod.AmmoCost);
        }
    }
}
