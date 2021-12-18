using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.ShotgunClasses
{
    public class ShotgunBaseMode : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;
        public event Action OnShotgunBaseModFire;

        private D_ShotgunBaseMod D_shotgunBaseMod;

        public GunAmmoRequest AmmoRequestSender { get; set; }


        public ShotgunBaseMode(ShotgunInput shotgunInput, D_ShotgunBaseMod D_shotgunBaseMod, GunShellAmmoContainer shellAmmoContainer)
        {
            this.D_shotgunBaseMod = D_shotgunBaseMod;

            AmmoRequestSender = new GunAmmoRequest(shellAmmoContainer, AmmoRequest);

            shotgunInput.OnBaseModFireInputDown += OnInputDown;

            OnShotgunBaseModFire += SetLastTimeFired;
            OnShotgunBaseModFire += SpawnProjectile;
            OnShotgunBaseModFire += RequestAmmo;
        }


        private void OnInputDown()
        {
            if (AmmoRequestSender.GetAmmoValue() > 0 && GetTimeSinceLastFirePassed(D_shotgunBaseMod.MinTimeBtwFire))
            {
                OnShotgunBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_shotgunBaseMod.AmmoCost);
        }
    }
}