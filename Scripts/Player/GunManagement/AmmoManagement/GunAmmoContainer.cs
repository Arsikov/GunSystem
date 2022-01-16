using System;
using ResourceClasses;

namespace GunClasses.AmmoClasses
{
    public abstract class GunAmmoContainer : Resource
    {
        protected GunAmmoContainer()
        {
            OnModifyValue += CallOnModifyAmmoEvent;
        }

        public void CallOnModifyAmmoEvent(int reduction)
        {
            OnModifyValue?.Invoke(reduction);
        }
    }
}