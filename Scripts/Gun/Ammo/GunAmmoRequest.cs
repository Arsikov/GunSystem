using System;
using GunClasses.DataClasses;

namespace GunClasses.AmmoClasses
{
    public class GunAmmoRequest
    {
        private GunAmmoContainer  _ammoContainer;

        public GunAmmoRequest(GunAmmoContainer ammoContainer, Action<int> AmmoRequest)
        {
            _ammoContainer = ammoContainer;

            AmmoRequest += AmmoRequest;
        }

        private void AmmoRequest(int value)
        {
            _ammoContainer.CallOnModifyAmmoEvent(value);
        }

        public int GetAmmoValue()
        {
            return _ammoContainer.AmmoAmount;
        }
    }
}
