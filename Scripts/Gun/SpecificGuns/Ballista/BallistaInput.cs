using System;
using GunClasses.DataClasses;

namespace GunClasses.BallistaClasses
{
    public class BallistaInput : GunInput
    {
        public event Action OnBaseModFireInputDown;

        public event Action OnBladeModEnableInputDown;
        public event Action OnBladeModChargeInputPressed;
        public event Action OnBladeModDisableInputUp;

        public event Action OnBladeModFireInputDown;

        public BallistaInput(D_GunModFireInput D_gunModFireInput) : base(D_gunModFireInput)
        {
        }

        protected override void HandleInput()
        {
            HandleBaseModInput();
            HandleBladeModInput();
        }

        private void HandleBaseModInput()
        {
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBaseModFireInputDown?.Invoke();
            }
        }

        private void HandleBladeModInput()
        {
            if (GetKeyDown(D_gunModFireInput.WeaponMod))
            {
                OnBladeModEnableInputDown?.Invoke();
            }
            if (GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBladeModChargeInputPressed?.Invoke();
            }
            if (GetKeyUp(D_gunModFireInput.WeaponMod))
            {
                OnBladeModDisableInputUp?.Invoke();
            }

            if (GetKeyDown(D_gunModFireInput.FireWeapon) && GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBladeModFireInputDown?.Invoke();
            }
        }
    }
}
