using System;
using GunClasses.DataClasses;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunInput : GunInput   
    {
        public event Action OnBaseModFireInputDown;
        public event Action OnBaseModFireInputPressed;

        public event Action OnShieldModEnableInputDown;
        public event Action OnShieldModEnableInputPressed;
        public event Action OnShieldModDisableInputUp;

        public ChaingunInput(D_GunModFireInput D_gunModFireInput) : base(D_gunModFireInput)
        {
        }

        protected override void HandleInput()
        {
            HandleBaseModInput();
            HandleShieldModInput();
        }

        private void HandleBaseModInput()
        {
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBaseModFireInputDown?.Invoke();
            }
            if (GetKey(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBaseModFireInputPressed?.Invoke();
            }
        }

        private void HandleShieldModInput()
        {
            if (GetKeyDown(D_gunModFireInput.WeaponMod))
            {
                OnShieldModEnableInputDown?.Invoke();
            }
            if (GetKey(D_gunModFireInput.WeaponMod))
            {
                OnShieldModEnableInputPressed?.Invoke();
            }
            if (GetKeyUp(D_gunModFireInput.WeaponMod))
            {
                OnShieldModDisableInputUp?.Invoke();
            }
        }
    }
}