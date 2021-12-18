using System;

namespace GunClasses.AmmoClasses
{
    public interface IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public GunAmmoRequest AmmoRequestSender { get; set; }

        protected void RequestAmmo();
    }
}
