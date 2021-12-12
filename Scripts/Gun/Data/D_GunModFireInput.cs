using UnityEngine;

namespace GunClasses.DataClasses
{
    [CreateAssetMenu(menuName = "KeyBindings/GunModeFireInput")]
    public class D_GunModFireInput : ScriptableObject
    {
        public KeyCode FireWeapon;
        public KeyCode WeaponMod;
    }
}
