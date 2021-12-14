using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.PlasmaClasses
{
    public class PlasmaRifleStunBlastMod : GunMod
    {
        public event Action OnPlasmaRifleStunBlastModFire;

        private PlasmaRifleInput _plasmaRifleInput;
        private D_PlasmaRifleStunBlastMod D_plasmaRifleStunBlastMod;

        private int _currentStunBlastAmount;
        private int _currentStunBlastChargeExtent;

        public PlasmaRifleStunBlastMod(PlasmaRifleInput plasmaRifleInput, D_PlasmaRifleStunBlastMod D_plasmaRifleStunBlastMod, PlasmaRifleBaseMod plasmaRifleBaseMod)
        {
            _plasmaRifleInput = plasmaRifleInput;

            this.D_plasmaRifleStunBlastMod = D_plasmaRifleStunBlastMod;

            _currentStunBlastAmount = 0;
            _currentStunBlastChargeExtent = 0;

            plasmaRifleInput.OnStunBlastModFireInputDown += OnInputDown;
            plasmaRifleBaseMod.OnPlasmaRifleBaseModFire += ChargeStunBlast;

            OnPlasmaRifleStunBlastModFire += SpendStunBlastAmount;
        }

        private void OnInputDown()
        {
            if (_currentStunBlastAmount > 0 && GetTimeSinceLastFirePassed(D_plasmaRifleStunBlastMod.MinTimeBtwFire))
            {
                OnPlasmaRifleStunBlastModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        private void SpendStunBlastAmount()
        {
            _currentStunBlastAmount--;
        }

        private void ChargeStunBlast()
        {
            _currentStunBlastChargeExtent += 1;

            if (_currentStunBlastAmount == D_plasmaRifleStunBlastMod.BaseShotToBlastWeightRelation)
            {
                if (_currentStunBlastAmount == D_plasmaRifleStunBlastMod.BlastMaxAmoutn)
                {
                    return;
                }
                else
                {
                    _currentStunBlastAmount++;
                    _currentStunBlastChargeExtent = 0;
                }
            }
        }
    }
}
