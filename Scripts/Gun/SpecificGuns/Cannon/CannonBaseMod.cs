using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.CannonClasses
{
    public class CannonBaseMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnCannonBaseModFire;

        private CannonInput _cannonInput;
        private D_CannonBaseMod D_cannonBaseMod;

        public GunAmmoRequest AmmoRequestSender { get; }

        public CannonBaseMod(CannonInput cannonInput, D_CannonBaseMod D_cannonBaseMod, GunBulletAmmoContainer bulletAmmoContainer)
        {
            _cannonInput = cannonInput;

            this.D_cannonBaseMod = D_cannonBaseMod;

            AmmoRequestSender = new GunAmmoRequest(bulletAmmoContainer, AmmoRequest);

            #region Events
            cannonInput.OnBaseModFireInputDown += OnInputDown;

            OnCannonBaseModFire += SetLastTimeFired;
            OnCannonBaseModFire += RequestAmmo;
            OnCannonBaseModFire += SpawnProjectile;
            #endregion
        }

        private void OnInputDown()
        {
            if (AmmoRequestSender.GetResourceValue() > 0 && GetTimeSinceLastFirePassed(D_cannonBaseMod.MinTimeBtwFire))
            {
                OnCannonBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_cannonBaseMod.AmmoCost);
        }
    }
}
