using System;
using GunClasses.DataClasses;

namespace GunClasses.AmmoClasses
{
    public class GunAmmoRequestSender
    {

        private GunAmmoContainer  _ammoContainer;
        private D_GunMod D_gunMod;

        public GunAmmoRequestSender(GunAmmoContainer ammoContainer, Action GunModTriggerEvent, D_GunMod D_gunMod)
        {
            _ammoContainer = ammoContainer;
            this.D_gunMod = D_gunMod;

            GunModTriggerEvent += RequestAmmoRedution;
        }

        private void RequestAmmoRedution()
        {
            _ammoContainer.CallOnReduceAmmoEvent(D_gunMod.AmmoCostOnTrigger);
        }
        private void RequestAmmoAddition()
        {
            _ammoContainer.CallOnAddAmmoEvent(D_gunMod.AmmoCostOnTrigger);
        }
    }
}
