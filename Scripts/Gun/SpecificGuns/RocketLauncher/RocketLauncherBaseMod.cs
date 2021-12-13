using System;
using GunClasses.AmmoClasses;

namespace GunClasses.RocketClasses
{
    public class RocketLauncherBaseMod : GunMod
    {
        public event Action OnShotgunBaseModFire;

        private RocketLauncherInput _rocketLauncherInput;
        private D_RocketLauncherBaseMod D_rocketLauncherBaseMod;
        private GunShellAmmoContainer _shellAmmoContainer;

        public RocketLauncherBaseMod(RocketLauncherInput rocketLauncherInput, D_RocketLauncherBaseMod D_rocketLauncherBaseMod, GunShellAmmoContainer shellAmmoContainer)
        {
            _rocketLauncherInput = rocketLauncherInput;

            this.D_rocketLauncherBaseMod = D_rocketLauncherBaseMod;

            _shellAmmoContainer = shellAmmoContainer;

            rocketLauncherInput.OnBaseModFireInputDown += OnInputDown;

            OnShotgunBaseModFire += SetLastTimeFired;
            OnShotgunBaseModFire += SpawnProjectile;
            OnShotgunBaseModFire += ReduceAmmo;
        }

        private void OnInputDown()
        {
            if (_shellAmmoContainer.AmmoAmount > 0 && GetTimeSinceLastFirePassed(D_rocketLauncherBaseMod.MinTimeBtwFire))
            {
                OnShotgunBaseModFire?.Invoke();
            }
        }

        private void SpawnProjectile()
        {

        }

        private void ReduceAmmo()
        {
            _shellAmmoContainer.CallOnReduceAmmoEvent(D_rocketLauncherBaseMod.AmmoCost);
        }
    }
}
