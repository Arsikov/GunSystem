using System;
using GunClasses.DataClasses;

namespace GunClasses.PlasmaClasses
{
    public class PlasmaRifleInput : GunInput
    {
        public event Action OnBaseModFireInputDown;
        public event Action OnBaseModFireInputPressed;

        public event Action OnStunBlastModFireInputDown;

        public PlasmaRifleInput(D_GunModFireInput D_gunModFireInput) : base(D_gunModFireInput)
        {
        }

        protected override void HandleInput()
        {
            HandleBaseModInput();
            HandleStunBlastModInput();
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

        private void HandleStunBlastModInput()
        {
            if (GetKeyDown(D_gunModFireInput.WeaponMod))
            {
                OnStunBlastModFireInputDown?.Invoke();
            }
        }
    }
}
