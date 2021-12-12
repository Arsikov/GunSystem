using System;

namespace GunClasses.AmmoClasses
{
    public abstract class GunAmmoContainer
    {
        public event Action<int> OnReduceAmmo;
        public event Action<int> OnAddAmmo;

        public int AmmoAmount { get; private set; }

        protected GunAmmoContainer()
        {
            OnReduceAmmo += ReduceAmmo;
            OnAddAmmo += OnAddAmmo;
        }

        protected void ReduceAmmo(int reduction)
        {
            AmmoAmount -= reduction;
        }

        protected void AddAmmo(int addition)
        {
            AmmoAmount += addition;
        }

        public void CallOnReduceAmmoEvent(int reduction)
        {
            OnReduceAmmo?.Invoke(reduction);
        }
        public void CallOnAddAmmoEvent(int addition)
        {
            OnReduceAmmo?.Invoke(addition);
        }
    }
}