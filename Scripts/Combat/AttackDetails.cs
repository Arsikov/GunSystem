using UnityEngine;

public struct AttackDetails 
{

    public int Damage { get; private set; }
    public Vector2 PushVel { get; private set; }

    public AttackDetails(int Damage, Vector2 PushVel)
    {
        this.Damage = Damage;
        this.PushVel = PushVel;
    }

}
