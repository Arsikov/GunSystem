using System;

namespace GunClasses.Abilities
{
    public class HealthRefill : IGunAbility
    {
        public event Action EventToListenTo;

        public HealthRefill()
        {

        }

        protected void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
