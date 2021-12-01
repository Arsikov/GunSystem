using System;
using UnityEngine;

namespace PlayerClasses.HealthClasses
{
    class PlayerHealth : MonoBehaviour, IHealth
    {
        public event Action<int> OnGetDamage;
        public event Action OnDeath;

        public int MaxHealth;
        public int CurrentHealth { get; private set; }

        public PlayerHealth(int MaxHealth)
        {
            this.MaxHealth = MaxHealth;
            CurrentHealth = MaxHealth;
        }

        public void GetDamage(AttackDetails details)
        {
            CurrentHealth -= details.Damage;

            if (CurrentHealth <= 0) OnDeath();
        }
        public void Die()
        {

        }
    }
}
