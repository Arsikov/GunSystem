using UnityEngine;

namespace PlayerClasses.GunClasses.InputClasses
{
    [CreateAssetMenu(fileName = "PlayerGunKeyBindings", menuName = "KeyBindings/PlayerGun")]
    public class SwapKeyBindings : ScriptableObject
    {
        public KeyCode ChaingunSwapKeyCode;
        public KeyCode CannonSwapKeyCode;

        public KeyCode BallistaSwapKeyCode;
        public KeyCode PlasmaRifleSwapKeyCode;

        public KeyCode RocketLauncherSwapKeyCode;
        public KeyCode ShotgunSwapKeyCode;
    }
}
