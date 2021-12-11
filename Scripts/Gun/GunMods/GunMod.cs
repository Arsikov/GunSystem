using System;
using UnityEngine;

namespace GunClasses
{
    public abstract class GunMod
    {
        public event Action OnActivate;
        public event Action OnTrigger;

        public float LastTimeTrigger { get; set; }

        public GunMod()
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
