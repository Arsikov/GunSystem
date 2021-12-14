using System;
using GunClasses.DataClasses;

namespace GunClasses.CannonClasses
{
    public class CannonInput : GunInput
    {
        public event Action OnBaseModFireInputDown;

        public event Action OnFlameBlastModEnableInputDown;
        public event Action OnFlameBlastModChargeInputPressed;
        public event Action OnFlameBlastModDisableInputUp;

        public event Action OnFlameBlastModFireInputDown;

        public CannonInput(D_GunModFireInput D_gunModFireInput) : base(D_gunModFireInput)
        {
        }

        protected override void HandleInput()
        {
            HandleBaseModInput();
            HandleFlameBlastModInput();
        }

        private void HandleBaseModInput()
        {
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBaseModFireInputDown?.Invoke();
            }
        }

        private void HandleFlameBlastModInput()
        {
            if (GetKeyDown(D_gunModFireInput.WeaponMod))
            {
                OnFlameBlastModEnableInputDown?.Invoke();
            }
            if (GetKey(D_gunModFireInput.WeaponMod))
            {
                OnFlameBlastModChargeInputPressed?.Invoke();
            }
            if (GetKeyUp(D_gunModFireInput.WeaponMod))
            {
                OnFlameBlastModDisableInputUp?.Invoke();
            }

            if (GetKeyDown(D_gunModFireInput.FireWeapon) && GetKey(D_gunModFireInput.WeaponMod))
            {
                OnFlameBlastModFireInputDown?.Invoke();
            }
        }
    }
}
