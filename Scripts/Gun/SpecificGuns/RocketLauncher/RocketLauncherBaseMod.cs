using System;
using GunClasses.AmmoClasses;

namespace GunClasses.RocketClasses
{
    public class RocketLauncherBaseMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnRocketLauncherBaseModFire;

        private RocketLauncherInput _rocketLauncherInput;
        private D_RocketLauncherBaseMod D_rocketLauncherBaseMod;

        public GunAmmoRequest AmmoRequestSender { get; }

        public RocketLauncherBaseMod(RocketLauncherInput rocketLauncherInput, D_RocketLauncherBaseMod D_rocketLauncherBaseMod, GunShellAmmoContainer shellAmmoContainer)
        {
            _rocketLauncherInput = rocketLauncherInput;

            this.D_rocketLauncherBaseMod = D_rocketLauncherBaseMod;

            AmmoRequestSender = new GunAmmoRequest(shellAmmoContainer, AmmoRequest);

            #region Events
            rocketLauncherInput.OnBaseModFireInputDown += OnInputDown;

            OnRocketLauncherBaseModFire += SetLastTimeFired;
            OnRocketLauncherBaseModFire += SpawnProjectile;
            OnRocketLauncherBaseModFire += RequestAmmo;
            #endregion
        }

        private void OnInputDown()
        {
            if (AmmoRequestSender.GetResourceValue() > 0 && GetTimeSinceLastFirePassed(D_rocketLauncherBaseMod.MinTimeBtwFire))
            {
                OnRocketLauncherBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        protected void RequestAmmo()
        {
            AmmoRequest?.Invoke(-D_rocketLauncherBaseMod.AmmoCost);
        }
    }
}
