using UnityEngine;

namespace GunClasses.DataClasses
{
    [CreateAssetMenu(menuName = "KeyBindings/GunModeTriggerInput")]
    public class D_GunModTriggerInput : ScriptableObject
    {
        public KeyCode BaseModTriggerInput;
        public KeyCode SpecialModTriggerInput;
    }
}
