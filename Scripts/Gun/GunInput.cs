using UnityEngine;
using GunClasses.DataClasses;

namespace GunClasses
{
    public abstract class GunInput
    {
        protected D_GunModFireInput D_gunModFireInput;

        public GunInput(D_GunModFireInput D_gunModFireInput)
        {
            this.D_gunModFireInput = D_gunModFireInput;
        }

        public void Execute()
        {
            HandleInput();
        }

        protected abstract void HandleInput();

        protected bool GetKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
        protected bool GetKey(KeyCode key)
        {
            return Input.GetKey(key);
        }
        protected bool GetKeyUp(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }
    }
}
