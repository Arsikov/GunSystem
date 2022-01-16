using System;
using UnityEngine;
using ResourceClasses;

namespace PlayerClasses.HealthClasses
{
    class PlayerHealth : Resource
    {
        public event Action OnDeath;

        public int MaxValue { get; private set; }

        public PlayerHealth(int MaxValue)
        {
            this.MaxValue = MaxValue;
            Value = MaxValue;
        }

        protected override void ModifyValue(int modifyValue)
        {
            base.ModifyValue(modifyValue);

            if (Value <= 0) OnDeath();
        }

        private void Die()
        {

        }
    }
}
