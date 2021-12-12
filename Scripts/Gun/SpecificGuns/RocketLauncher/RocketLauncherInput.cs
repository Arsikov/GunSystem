using GunClasses.DataClasses;
using System;

namespace GunClasses.RocketClasses
{
    public class RocketLauncherInput : GunInput
    {

        public event Action OnBaseModFireInputDown;

        public event Action OnBurstModEnableInputDown;
        public event Action OnBurstModChargeInputPressed;
        public event Action OnBurstModDisableInputUp;
        public RocketLauncherInput(D_GunModFireInput D_gunModFireInput) : base(D_gunModFireInput)
        {
        }

        protected override void HandleInput()
        {
            HandleBaseModInput();
            HandleBurstModInput();
        }

        private void HandleBaseModInput()
        {
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBaseModFireInputDown?.Invoke();
            }
        }
        private void HandleBurstModInput()
        {
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBurstModEnableInputDown?.Invoke();
            }
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBurstModChargeInputPressed?.Invoke();
            }
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBurstModDisableInputUp?.Invoke();
            }
        }
    }
}
