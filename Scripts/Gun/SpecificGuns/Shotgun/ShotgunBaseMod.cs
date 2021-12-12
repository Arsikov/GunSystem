using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.ShotgunClasses
{
    public class ShotgunBaseMode : GunMod
    {
        public event Action OnShotgunBaseModFire;

        private ShotgunInput _shotgunInput;
        private D_ShotgunBaseMod D_shotgunBaseMod;
        private GunShellAmmoContainer _shellAmmoContainer;

        public ShotgunBaseMode(ShotgunInput shotgunInput, D_ShotgunBaseMod D_shotgunBaseMod, GunShellAmmoContainer shellAmmoContainer)
        {
            _shotgunInput = shotgunInput;

            this.D_shotgunBaseMod = D_shotgunBaseMod;

            _shellAmmoContainer = shellAmmoContainer;

            shotgunInput.OnBaseModInputDown += OnInputDown;

            OnShotgunBaseModFire += SetLastTimeFired;
            OnShotgunBaseModFire += SpawnProjectile;
            OnShotgunBaseModFire += ReduceAmmo;
        }

        private void OnInputDown()
        {
            if (_shellAmmoContainer.AmmoAmount > 0 && GetTimeSinceLastFirePassed(D_shotgunBaseMod.MinTimeBtwFire))
            {
                OnShotgunBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        private void ReduceAmmo()
        {
            _shellAmmoContainer.CallOnReduceAmmoEvent(D_shotgunBaseMod.AmmoCost);
        }
    }
}