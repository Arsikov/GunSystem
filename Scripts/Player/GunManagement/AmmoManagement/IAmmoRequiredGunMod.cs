using System;
using ResourceClasses;

namespace GunClasses.AmmoClasses
{
    public interface IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public ResourceRequest AmmoRequestSender { get; }

        protected virtual void RequestAmmo() { }
    }
}
