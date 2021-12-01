using System;
using UnityEngine;

namespace GunClasses.InputClasses
{
    [CreateAssetMenu(fileName = "GunKeyBindings", menuName = "KeyBindings/Gun")]
    public class KeyBindings : ScriptableObject
    {
        public KeyBindingCheck[] keyBindingChecks;

        [Serializable]
        public class KeyBindingCheck
        {
            public KeyBindingsActions action;
            public KeyCode keyCode;
        }
    }
}
