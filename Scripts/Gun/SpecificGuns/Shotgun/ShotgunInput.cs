using System;
using GunClasses.DataClasses; 

namespace GunClasses.ShotgunClasses
{
    public class ShotgunInput : GunInput
    {
        public event Action OnBaseModFireInputDown;

        public event Action OnFullAutoModEnableInputDown;
        public event Action OnFullAutoModEnableInputPressed;
        public event Action OnFullAutoModDisableInputUp;

        public event Action OnFullAutoModFireInputDown;
        public event Action OnFullAutoModFireInputPressed;

        public ShotgunInput(D_GunModFireInput D_gunModFireInput) : base(D_gunModFireInput)
        {
        }

        protected override void HandleInput()
        {
            HandleBaseModInput();
            HandleFullAutoModInput();
        }

        private void HandleBaseModInput()
        {
            if (GetKeyDown(D_gunModFireInput.FireWeapon) && !GetKey(D_gunModFireInput.WeaponMod))
            {
                OnBaseModFireInputDown.Invoke();
            }
        }

        private void HandleFullAutoModInput()
        {
            if (GetKeyDown(D_gunModFireInput.WeaponMod))
            {
                OnFullAutoModEnableInputDown?.Invoke();
            }
            if (GetKey(D_gunModFireInput.WeaponMod))
            {
                OnFullAutoModEnableInputPressed?.Invoke();
            }
            if (GetKeyUp(D_gunModFireInput.WeaponMod))
            {
                OnFullAutoModDisableInputUp?.Invoke();
            }


            if (GetKeyDown(D_gunModFireInput.FireWeapon) && GetKey(D_gunModFireInput.WeaponMod))
            {
                OnFullAutoModFireInputDown?.Invoke();
            }
            if (GetKey(D_gunModFireInput.FireWeapon) && GetKey(D_gunModFireInput.WeaponMod))
            {
                OnFullAutoModFireInputPressed?.Invoke();
            }
        }
    }   
}