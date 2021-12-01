using System;
using UnityEngine;

namespace GunClasses
{
    public abstract class GunMode
    {
        public event Action OnActivate;
        public event Action OnTrigger;

        protected Gun gun;

        protected virtual void Execute()
        {

        }

        protected virtual void Activate(KeyCode activityInput)
        {

        }

        protected virtual void Trigger(KeyCode triggerInput)
        {

        }
    }
}
