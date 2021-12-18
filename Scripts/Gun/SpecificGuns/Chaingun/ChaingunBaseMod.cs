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

        protected GunAmmoRequest _ammoRequest;

        private float _attackTime;

        public ChaingunBaseMod(ChaingunInput chaingunInput, D_ChaingunBaseMod D_chaingunBaseMod, GunBulletAmmoContainer bulletAmmoContainer)
        {
            _chaingunInput = chaingunInput;

            this.D_chaingunBaseMod = D_chaingunBaseMod;

            _bulletAmmoContainer = bulletAmmoContainer;
            _attackTime = D_chaingunBaseMod.AttackTime;

            chaingunInput.OnBaseModFireInputDown += OnInputDown;
            chaingunInput.OnBaseModFireInputPressed += OnInputPressed;

            OnChaingunBaseModFire += SetLastTimeFired;
            OnChaingunBaseModFire += RequestAmmo;
            OnChaingunBaseModFire += SpawnProjectile;
        }

        private void OnInputDown()
        {
            if (_bulletAmmoContainer.AmmoAmount > 0 && GetTimeSinceLastFirePassed(D_chaingunBaseMod.MinTimeBtwFire))
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

        public void RequestAmmo()
        {
            _bulletAmmoContainer.CallOnModifyAmmoEvent(-D_chaingunBaseMod.AmmoCost);
        }
    }
}