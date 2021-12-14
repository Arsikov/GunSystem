using System;
using GunClasses.DataClasses;

namespace GunClasses.RocketClasses
{
    public class RocketLauncherInput : GunInput
    {
        public event Action OnBaseModFireInputDown;

        public event Action OnBurstModEnableInputDown;
        public event Action OnBurstModChargeInputPressed;
        public event Action OnBurstModDisableInputUp;

        public event Action OnBurstModFireInputDown;

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
            if (GetKey(D_gunModFireInput.FireWeapon))
            {
                OnBurstModChargeInputPressed?.Invoke();
            }
            if (GetKeyUp(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBurstModDisableInputUp?.Invoke();
            }
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && GetKey(D_gunModFireInput.FireWeapon))
            {
                OnBurstModFireInputDown?.Invoke();
            }
        }
    }
}
