using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunBaseMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnChaingunBaseModFire;

        private ChaingunInput _chaingunInput;
        private D_ChaingunBaseMod D_chaingunBaseMod;

        public GunAmmoRequest AmmoRequestSender { get; }

        private float _attackTime;

        public ChaingunBaseMod(ChaingunInput chaingunInput, D_ChaingunBaseMod D_chaingunBaseMod, GunBulletAmmoContainer bulletAmmoContainer)
        {
            _chaingunInput = chaingunInput;

            this.D_chaingunBaseMod = D_chaingunBaseMod;

            AmmoRequestSender = new GunAmmoRequest(bulletAmmoContainer, AmmoRequest);
            _attackTime = D_chaingunBaseMod.AttackTime;

            #region Events
            chaingunInput.OnBaseModFireInputDown += OnInputDown;
            chaingunInput.OnBaseModFireInputPressed += OnInputPressed;

            OnChaingunBaseModFire += SetLastTimeFired;
            OnChaingunBaseModFire += RequestAmmo;
            OnChaingunBaseModFire += SpawnProjectile;
            #endregion
        }

        private void OnInputDown()
        {
            if (AmmoRequestSender.GetResourceValue() > 0 && GetTimeSinceLastFirePassed(D_chaingunBaseMod.MinTimeBtwFire))
            {
                OnChaingunBaseModFire?.Invoke();
            }
        }

        private void OnInputPressed()
        {
            _attackTime -= Time.deltaTime;

            if (_attackTime <= 0)
            {
                _attackTime = D_chaingunBaseMod.AttackTime;
                OnChaingunBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_chaingunBaseMod.AmmoCost);
        }
    }
}