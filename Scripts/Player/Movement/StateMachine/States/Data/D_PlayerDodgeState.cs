using UnityEngine;

namespace PlayerClasses.MovementClasses.StateClasses
{
    [CreateAssetMenu(menuName = "Player/State/Dodge")]
    public class D_PlayerDodgeState : ScriptableObject
    {
        public int Speed;
        public float PerformTime;
        public float Cooldown;
    }
}
