using System;

namespace GunClasses.Abilities
{
    public class HealthCredit : IGunAbility
    {
        public event Action EventToListenTo;

        public HealthCredit()
        {

        }

        protected void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
