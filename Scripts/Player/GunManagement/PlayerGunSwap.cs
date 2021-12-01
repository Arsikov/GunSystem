using System;
using UnityEngine;
using GunClasses;
using PlayerClasses.GunClasses.InputClasses;

namespace PlayerClasses.GunClasses
{
    public class PlayerGunSwap
    {
        public Gun CurrentGun { get; private set; }
        public Gun[] Guns { get; private set; }

        public event Action<Gun> OnGunSwap;

        private KeyCode[] _gunSwapKeyBindings;

        public PlayerGunSwap(Gun[] guns, SwapKeyBindings swapKeyBindings)
        {
            Guns = guns;

            _gunSwapKeyBindings = new KeyCode[] 
            { 
                swapKeyBindings.ChaingunSwapKeyCode, 
                swapKeyBindings.CannonSwapKeyCode, 

                swapKeyBindings.BallistaSwapKeyCode, 
                swapKeyBindings.PlasmaRifleSwapKeyCode, 

                swapKeyBindings.RocketLauncherSwapKeyCode,
                swapKeyBindings.ShotgunSwapKeyCode
            };
        }

        public void HandleSwapInput()
        {
            for(int i = 0; i < Guns.Length; i++)
            {
                if (Input.GetKeyDown(_gunSwapKeyBindings[i]))
                {
                    SelectGun(i);
                }
            }
        }

        private void SelectGun(int index)
        {
            for(int i = 0; i < Guns.Length; i++)
            {
                if (i == index)
                {
                    Guns[i].gameObject.SetActive(true);
                    CurrentGun = Guns[i];
                    OnGunSwap?.Invoke(CurrentGun);
                }
                Guns[i].gameObject.SetActive(false);
            }
        }
    }
}