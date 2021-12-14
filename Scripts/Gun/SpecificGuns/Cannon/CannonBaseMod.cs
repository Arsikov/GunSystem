using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.CannonClasses
{
    public class CannonBaseMod : GunMod
    {
        public event Action OnCannonBaseModFire;

        private CannonInput _cannonInput;
        private D_CannonBaseMod D_cannonBaseMod;
        private GunBulletAmmoContainer _bulletAmmoContainer;

        public CannonBaseMod(CannonInput cannonInput, D_CannonBaseMod D_cannonBaseMod, GunBulletAmmoContainer bulletAmmoContainer)
        {
            _cannonInput = cannonInput;

            this.D_cannonBaseMod = D_cannonBaseMod;

            _bulletAmmoContainer = bulletAmmoContainer;

            cannonInput.OnBaseModFireInputDown += OnInputDown;

            OnCannonBaseModFire += SetLastTimeFired;
            OnCannonBaseModFire += ReduceAmmo;
            OnCannonBaseModFire += SpawnProjectile;
        }

        private void OnInputDown()
        {
            if (_bulletAmmoContainer.AmmoAmount > 0 && GetTimeSinceLastFirePassed(D_cannonBaseMod.MinTimeBtwFire))
            {
                OnCannonBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        private void ReduceAmmo()
        {
            _bulletAmmoContainer.CallOnReduceAmmoEvent(D_cannonBaseMod.AmmoCost);
        }
    }
}
