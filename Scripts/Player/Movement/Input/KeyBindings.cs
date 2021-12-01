using UnityEngine;
using System;

namespace PlayerClasses.MovementClasses.InputClasses
{
    [CreateAssetMenu(menuName = "KeyBindings/PlayerMovement")]
    public class KeyBindings : ScriptableObject
    {
        public KeyBindingValue[] values;

        [Serializable]
        public class KeyBindingValue
        {
            public KeyActions action;
            public KeyCode keyCode;
        }
    }
}
