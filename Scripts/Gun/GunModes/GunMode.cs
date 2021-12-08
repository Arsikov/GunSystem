using System;
using UnityEngine;

namespace GunClasses
{
    public abstract class GunMode
    {
        public event Action OnActivate;
        public event Action OnTrigger;

        public float LastTimeTrigger { get; set; }

        public GunMode()
        {
            OnActivate += Activate;
            OnTrigger += Trigger;
        }

        // update per frame
        public abstract void Update();

        protected abstract void Activate();

        protected abstract void Trigger();
    }
}
