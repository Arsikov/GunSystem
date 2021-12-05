using System;
using UnityEngine;

namespace GunClasses
{
    public abstract class GunInput
    {
        public void Execute()
        {
            OnHandleInput();
        }

        protected virtual void OnHandleInput()
        {

        }
    }
}
