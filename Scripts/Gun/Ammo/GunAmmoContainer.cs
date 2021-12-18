using System;

namespace GunClasses.AmmoClasses
{
    public abstract class GunAmmoContainer
    {
        public event Action<int> OnModifyAmmo;

        public int AmmoAmount { get; private set; }

        protected GunAmmoContainer()
        {
            OnModifyAmmo += CallOnModifyAmmoEvent;
        }

        protected void ReduceAmmo(int reduction)
        {
            AmmoAmount -= reduction;
        }

        protected void AddAmmo(int addition)
        {
            AmmoAmount += addition;
        }

        public void CallOnModifyAmmoEvent(int reduction)
        {
            OnModifyAmmo?.Invoke(reduction);
        }
    }
}