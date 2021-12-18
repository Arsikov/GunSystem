using System;
using GunClasses.AmmoClasses;

namespace GunClasses.RocketClasses
{
    public class RocketLauncherBaseMod : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnShotgunBaseModFire;

        private RocketLauncherInput _rocketLauncherInput;
        private D_RocketLauncherBaseMod D_rocketLauncherBaseMod;

        protected GunAmmoRequest _ammoRequest;

        public RocketLauncherBaseMod(RocketLauncherInput rocketLauncherInput, D_RocketLauncherBaseMod D_rocketLauncherBaseMod, GunShellAmmoContainer shellAmmoContainer)
        {
            _rocketLauncherInput = rocketLauncherInput;

            this.D_rocketLauncherBaseMod = D_rocketLauncherBaseMod;

            _shellAmmoContainer = shellAmmoContainer;

            rocketLauncherInput.OnBaseModFireInputDown += OnInputDown;

            OnShotgunBaseModFire += SetLastTimeFired;
            OnShotgunBaseModFire += SpawnProjectile;
            OnShotgunBaseModFire += RequestAmmo;
        }

        private void OnInputDown()
        {
            if (_ammoRequest.GetAmmoValue() > 0 && GetTimeSinceLastFirePassed(D_rocketLauncherBaseMod.MinTimeBtwFire))
            {
                OnShotgunBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        public void RequestAmmo()
        {
            _shellAmmoContainer.CallOnModifyAmmoEvent(-D_rocketLauncherBaseMod.AmmoCost);
        }
    }
}
