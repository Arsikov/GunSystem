using System;
using UnityEngine;

namespace GunClasses
{
    public abstract class GunMode
    {
        public event Action OnActivate;
        public event Action OnTrigger;

        public GunMode()
        {
            OnActivate += Activate;
            OnTrigger += Trigger;
        }

        // update per frame
        protected virtual void Execute()
        {

        }

        protected virtual void Activate()
        {

        }

        protected virtual void Trigger()
        {

        }
    }
}
