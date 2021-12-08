using UnityEngine;

namespace GunClasses.DataClasses
{
    [CreateAssetMenu(menuName = "KeyBindings/GunModeTriggerInput")]
    public class D_GunModeTriggerInput : ScriptableObject
    {
        public KeyCode BaseModeTriggerInput;
        public KeyCode SpecialModeTriggerInput;
    }
}
