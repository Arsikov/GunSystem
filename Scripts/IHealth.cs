using System;

public interface IHealth 
{
    public event Action<int> OnGetDamage;
    public event Action OnDeath;

    void GetDamage(AttackDetails details);
    void Die();
}
